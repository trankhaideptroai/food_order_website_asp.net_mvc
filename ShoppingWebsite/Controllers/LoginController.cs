using Microsoft.AspNetCore.Mvc;

namespace ShoppingWebsite.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
