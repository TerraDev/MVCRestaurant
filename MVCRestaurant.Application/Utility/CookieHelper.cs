using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRestaurant.Application.Utility
{
    public class CookieHelper
    {
        private readonly OrderService _orderService;
        public CookieHelper(OrderService orderService)
        {
            _orderService = orderService;
        }

        //cookie exists? - request.cookies
        public bool CookieExists(ControllerBase Controller, string CookieKey)
        {
            return Controller.Request.Cookies.ContainsKey(CookieKey);
        }

        //get cookie - request.cookies
        public string GetCookie(ControllerBase controller, string CookieKey)
        {
            return controller.Request.Cookies[CookieKey]!;
        }

        //create cookie - response.cookies
        public async Task<string> CreateCookieOrderIdentifier(ControllerBase controller, string CookieKey)
        {
            string? CookieVal = await _orderService.CreateOrderIdentifier();
            controller.Response.Cookies.Append(CookieKey, CookieVal!, new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddDays(4),
            });
            return CookieVal;
        }


        //delete cookie - response.cookies
        public void DeleteCookie(ControllerBase controller, string CookieKey)
        {
            controller.Response.Cookies.Delete(CookieKey);
        }

        //get foodId-quantity dictionary - utilizes orderService
        public async Task<Dictionary<ulong,uint>> GetFoodCountDictionaryFromCookie(string cookieKey)
        {
            return await _orderService.GetItemCountDictionary(cookieKey);
        }

        //get ordered food count - utilizes orderService
        public async Task<ushort> GetFoodCountFromCookie(string cookieKey)
        {
            return await _orderService.GetOrdersQuantity(cookieKey);
        }
    }
}
