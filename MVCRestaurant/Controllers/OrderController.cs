//using AspNetCore;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCRestaurant.Application;
using MVCRestaurant.Application.Utility;
using MVCRestaurant.Mapper;
using MVCRestaurant.Models;
using MVCRestaurant.ViewModels;
using MVCRestaurant.Views.Order;
using System.Data;
using System.Security.Claims;

namespace MVCRestaurant.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _Os;
        private readonly CookieHelper _Ch;
        private readonly LogService _Ls;

        public OrderController(OrderService Os, CookieHelper Ch, LogService Ls)
        {
            _Os = Os;
            _Ch = Ch;
            _Ls = Ls;
        }

        public async Task<ActionResult> AddToCart(ulong itemId, bool increment)
        {
            string id;
            if(!_Ch.CookieExists(this, "OrderIdentifier"))
            {
                id = await _Ch.CreateCookieOrderIdentifier(this, "OrderIdentifier");
            }
            else
            {
                id = _Ch.GetCookie(this, "OrderIdentifier");
            }
            //string id = "98A436E3-A8D8-4B23-95A2-6E2A83AD7CA4";

            uint quantity = await _Os.ChangeOrderItemQuantity(itemId, id, increment);
            ushort total = await _Ch.GetFoodCountFromCookie(id);
            return Ok(new { quantity = quantity, total = total });
        }

        public async Task<ActionResult> ShoppingCart()
        {
            try
            {
                //log
                await _Ls.AddLog(this.User.FindFirstValue("AltKey")??"N/A", "Viewing shopping cart.", false);
                //log

                string id;
                if (!_Ch.CookieExists(this, "OrderIdentifier"))
                {
                    id = await _Ch.CreateCookieOrderIdentifier(this, "OrderIdentifier");
                }
                else
                {
                    id = _Ch.GetCookie(this, "OrderIdentifier");
                }
                ulong price = await _Os.CalculateOrderPrice(id);
                OrderViewModel order = OrderMapper.OrderToVM(await _Os.GetOrderAsync(id));

                if (price != order.FinalPrice)
                {
                    throw new Exception("error");
                }

                return View(order);
            }
            catch (Exception ex)
            {
                if (await _Ch.GetFoodCountFromCookie("OrderIdentifier") == 0)
                {
                    return View(new OrderViewModel()
                    {
                        orderItems = new List<OrderItemViewModel>()
                    });
                }
                return Json(ex.Message);
            }
            
        }

        [Authorize]
        public async Task<ActionResult> MyOrders(int pageNum = 1)
        {
            (var orders, ViewBag.TotalPages) = await _Os.GetOrdersofUserAsync(pageNum, User.FindFirstValue("AltKey")??"0");
            return View(nameof(Index), orders.Select(x => OrderMapper.OrderToVM(x)));
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Purchase()
        {
            try
            {
                //log
                await _Ls.AddLog(this.User, "purchase init", false);
                //log

                string orderIdentifier;
                if (!_Ch.CookieExists(this, "OrderIdentifier"))
                {
                    throw new Exception("Security error");
                }
                else
                {
                    orderIdentifier = _Ch.GetCookie(this, "OrderIdentifier");
                }

                ulong price = await _Os.CalculateOrderPrice(orderIdentifier);
                OrderViewModel order = OrderMapper.OrderToVM(await _Os.GetOrderAsync(orderIdentifier));

                if (price == 0)
                {
                    throw new Exception("No item is ordered");
                }

                if (price != order.FinalPrice)
                {
                    throw new Exception("error");
                }

                if (!await _Os.AssignOrderToUser(orderIdentifier, 
                        ulong.Parse(this.User.FindFirstValue("AltKey") ?? "0")))
                {
                    throw new Exception("Identity error");
                }
                return View(order);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> PurchaseComplete(string Identifier)
        {
            try
            {
                //log
                await _Ls.AddLog(this.User, "purchase complete", false);
                //log

                string orderIdentifier;
                if (!_Ch.CookieExists(this, "OrderIdentifier"))
                {
                    throw new Exception("Security error");
                }
                else
                {
                    orderIdentifier = _Ch.GetCookie(this, "OrderIdentifier");
                    if (Identifier != orderIdentifier)
                        throw new Exception("Security error");
                }

                ulong price = await _Os.CalculateOrderPrice(orderIdentifier);
                OrderViewModel order = OrderMapper.OrderToVM(await _Os.GetOrderAsync(orderIdentifier));

                if (price == 0)
                {
                    throw new Exception("No food is ordered.");
                }

                if (price != order.FinalPrice)
                {
                    throw new Exception("error");
                }

                if (!await _Os.AssignOrderToUser(orderIdentifier,
                    ulong.Parse(this.User.FindFirstValue("AltKey")??"0")))
                {
                    throw new Exception("Identity error");
                }

                OrderViewModel newOrder = OrderMapper.OrderToVM(await _Os.CompleteOrder(orderIdentifier));
                _Ch.DeleteCookie(this, "OrderIdentifier");
                await _Ch.CreateCookieOrderIdentifier(this, "OrderIdentifier");
                ViewBag.HasHomePageButton = true;
                //return RedirectToAction(nameof(PrintInvoice), new { orderIdentifier= orderIdentifier });
                return View("PrintInvoice", newOrder);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            };
        }

        [Authorize]
        public async Task<IActionResult> PrintInvoice(string orderIdentifier)
        {
            //log
            await _Ls.AddLog(this.User, $"printing invoice with id {orderIdentifier}", false);
            //log

            ViewBag.HasHomePageButton = false;
            OrderViewModel order = OrderMapper.OrderToVM(await _Os.GetOrderAsync(orderIdentifier));
            return View(order);
        }

        public async Task<IActionResult> TotalCount()
        {
            string id;
            if (!_Ch.CookieExists(this, "OrderIdentifier"))
            {
                id = await _Ch.CreateCookieOrderIdentifier(this, "OrderIdentifier");
            }
            else
            {
                id = _Ch.GetCookie(this, "OrderIdentifier");
            }

            return Ok( new { quantity = await _Ch.GetFoodCountFromCookie(id)});
        }

        [Authorize(Roles = "Employee, Admin, SuperAdmin")]
        public async Task<ActionResult> Index(int PageNum = 1)
        {
            (var orders, ViewBag.TotalPages) = await _Os.GetOrdersAsync(PageNum);
            IEnumerable<OrderViewModel> ordersModel = (orders).Select(x => OrderMapper.OrderToVM(x));
            return View(ordersModel);
        }

        //This function tries to print the invoice as PDF and save it in wwwroot server ... didn't work
        /*
        //[Authorize]
        public async Task<ActionResult> PrintInvoice(string orderIdentifier)
        {
            //TODO: check if order belongs to current signed in user

            string orderIdentifier = "98A436E3-A8D8-4B23-95A2-6E2A83AD7CA4";
            OrderViewModel order = OrderMapper.OrderToVM(await _Os.GetOrderAsync(orderIdentifier));
            //var html = _PRINT_invoice.GetView(order);

            //string fileName = Guid.NewGuid().ToString() + "OrderInvoice.pdf";
            string fileName = "OrderInvoice.pdf";
            var actionResult = new ViewAsPdf("PrintableInvoice", order);
            var byteArray = actionResult.BuildPdf();
            await _Fs.StoreFileAsync(byteArray, fileName, "Invoices");

            return View("PrintableInvoice", order);
            //var globalSettings = new GlobalSettings
            //{
            //    Orientation = Orientation.Portrait,
            //    PaperSize = PaperKind.A4,
            //    DocumentTitle = fileName
            //};
            //var objectSettings = new ObjectSettings()
            //{
            //    HtmlContent = html,
            //};

            //return File(_PDFs.Render(globalSettings, objectSettings,"Invoices", fileName), MediaTypeNames.Application.Pdf, fileName);
        }
        */

    }
}
