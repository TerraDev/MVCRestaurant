using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCRestaurant.ViewModels;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace MVCRestaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult TestCookie()
        {
            if(Request.Cookies.ContainsKey("OrderIdentifier"))
            {
                Response.Cookies.Delete("OrderIdentifier");
                //return BadRequest(new { Message = "cookie already exists" });
            }

            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(4);
            var key = Guid.NewGuid().ToString();
            Response.Cookies.Append("OrderIdentifier", key, options);


            return Ok(new {name = "OrderIdentifier", value = key });
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult TestGetCookie()
        {
            string? str = Request.Cookies["OrderIdentifier"];
            
            return str != null ? Ok(new { GOODval = str }) : BadRequest(new {BADval = str });
        }
    }
}