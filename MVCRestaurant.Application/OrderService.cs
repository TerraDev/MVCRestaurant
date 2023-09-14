using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCRestaurant.Application.Utility;
using MVCRestaurant.Infrastructure;
using MVCRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRestaurant.Application
{
    public class OrderService
    {
        
        private readonly AppDbContext _ctx;

        public OrderService(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        internal async Task<bool> OrderIdentifierExists(string id)
        {
            return await _ctx.Orders.AnyAsync(x => x.Identifier == id);
        }

        internal async Task<string?> CreateOrderIdentifier(ulong userId = 0)
        {
            Order newOrder = new Order();
            if (userId != 0)
                newOrder.UserId = userId;
            newOrder.Tax = 0.2f;
            newOrder.OrderDate = DateTime.Now;

            var orderEntity = await _ctx.Orders.AddAsync(newOrder);

            if (await _ctx.SaveChangesAsync() > 0)
            {
                return orderEntity.Entity.Identifier;
            }
            else return null;
        }

        public async Task<bool> AssignOrderToUser(string orderid, ulong userId)
        {
            Order order = await _ctx.Orders.AsTracking().SingleAsync(x => x.Identifier == orderid);
            order.UserId = userId;

            _ctx.Entry<Order>(order).State = EntityState.Modified;
            if(await _ctx.SaveChangesAsync() > 0)
            {
                return true;
            }
            else return false;
        }

        public async Task<uint> ChangeOrderItemQuantity(ulong foodId, string orderid, bool increment)
        {
            if(! await _ctx.FoodItems.AnyAsync(x => x.Id == foodId))
            {
                throw new Exception("Food does not exist!");
            }

            if(!await this.OrderIdentifierExists(orderid))
            {
                throw new Exception("Order With provided identifier does not exist!");
            }


            OrderItem? item = await _ctx.OrderItems.IgnoreQueryFilters().AsTracking()
                .SingleOrDefaultAsync(x => x.OrderId == orderid && x.OrderedFoodId == foodId);

            if(item == null)
            {
                if (!increment)
                    throw new Exception("Cannot decrement an unordered food!!! Secret hit...");

                item = new OrderItem { 
                    OrderedFoodId = foodId,
                    quantity = 1,
                    OrderId = orderid,
                };
                await _ctx.OrderItems.AddAsync(item);
            }
            else if(item.quantity == 0 && !increment)
            {
                throw new Exception("Cannot decrement an unordered food!!! Secret hit...");
            }
            else
            {
                if (increment)
                    item.quantity++;
                else
                    item.quantity--;
                _ctx.Entry<OrderItem>(item).State = EntityState.Modified;
            }

            if (await _ctx.SaveChangesAsync() > 0)
            {
                return item.quantity;
            }
            else
                throw new Exception("couldn't change item quantity!");
        }
        
        //TODO: Calculate order price
        public async Task<ulong> CalculateOrderPrice(string orderId)
        {
            if(!_ctx.Orders.Any(x => x.Identifier == orderId))
            {
                throw new Exception("سفارشی یافت نشد.");
            }

            Order order =
            await _ctx.Orders.Include(x => x.OrderItems)
            .ThenInclude(y => y.OrderedFood).SingleAsync(x => x.Identifier == orderId);

            if(order.OrderItems.Count == 0)
            {
                throw new Exception("No food is ordered.");
            }

            order.Total = 0;

            foreach (OrderItem item in order.OrderItems)
            {
                order.Total += item.quantity * item.OrderedFood.Price;
            }

            order.FinalPrice = (ulong)(order.Total*(1f+order.Tax)) + order.DeliveryPrice;
            order.OrderDate = DateTime.Now;
            //order.OrderCompleted = true;

            _ctx.Entry<Order>(order).State = EntityState.Modified;
            if (await _ctx.SaveChangesAsync() > 0)
                return order.FinalPrice;
            else
                return 0;
        }

        //TODO: method to terminate cookie & assign new identifier to user after successful purchase

        //Get Order by Id with full details
        public async Task<Order> GetOrderAsync(string identifier)
        {
            return await _ctx.Orders.Include(x => x.OrderItems)
                .ThenInclude(x => x.OrderedFood).SingleAsync(x => x.Identifier == identifier);
        }

        //Get all orders (Pagination & no details)
        public async Task<(List<Order>, int)> GetOrdersAsync(int pageNum)
        {
            var itemsQuery = _ctx.Orders;
            return (await itemsQuery.OrderByDescending(x => x.OrderDate).Page<Order>(20, pageNum).ToListAsync(), (int)Math.Ceiling((await itemsQuery.CountAsync())/20f));
        }

        //Get all orders (Pagination & no details)
        public async Task<(List<Order>, int)> GetOrdersofUserAsync(int pageNum, string alt)
        {
            ulong number = ulong.Parse(alt);
            var itemsQuery = _ctx.Orders.Where(x => x.OrderedBy.AltKey == number);
            return (await itemsQuery.OrderByDescending(x => x.OrderDate).Page<Order>(20, pageNum).ToListAsync(), (int)Math.Ceiling((await itemsQuery.CountAsync()) / 20f));
        }

        internal async Task<ushort> GetOrdersQuantity(string orderId)
        {
            return (ushort)await _ctx.OrderItems.Where(x => x.OrderId == orderId).SumAsync(x => x.quantity);
        }

        internal async Task<Dictionary<ulong,uint>> GetItemCountDictionary(string orderId)
        {
            return await _ctx.OrderItems.Where(x => x.OrderId == orderId)
                .Select(x => new { x.OrderedFoodId, x.quantity }).ToDictionaryAsync(x => x.OrderedFoodId, x=> x.quantity);
        }

        public async Task<Order> CompleteOrder(string orderIdentifier)
        {
            Order order = await _ctx.Orders.AsTracking().SingleAsync(x => x.Identifier == orderIdentifier);
            order.OrderCompleted = true;
            order.OrderDate = DateTime.Now;
            await _ctx.SaveChangesAsync();

            return order;
        }
    }
}
