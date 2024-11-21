using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingWebsite.Models;
using System.Diagnostics;

namespace ShoppingWebsite.Controllers
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
            ViewData["Title"] = "Home";
            return View();
        }

        public IActionResult Privacy()
        {
            SetCartItemCount();
            return View();
        }
        private void SetCartItemCount()
    {
        var cart = HttpContext.Session.GetString("Cart");
        var cartItems = string.IsNullOrEmpty(cart) 
            ? new List<CartItem>() 
            : JsonConvert.DeserializeObject<List<CartItem>>(cart);
        
        ViewBag.CartItemCount = cartItems.Sum(c => c.Quantity);
    }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Login()
        {
            ViewData["Title"] = "Đăng nhập";
            return View();
        }

        public IActionResult Register()
        {
            ViewData["Title"] = "Đăng ký";
            return View();
        }

    }
}
