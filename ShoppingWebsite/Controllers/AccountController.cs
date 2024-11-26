using Microsoft.AspNetCore.Mvc;
using ShoppingWebsite.Interfaces;
using ShoppingWebsite.Models;

namespace ShoppingWebsite.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Login()
        {
            if (_accountService.IsUserLoggedIn(HttpContext))
            {
                return RedirectToAction("Index", "Products");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(Customer model)
        {
            if (_accountService.Login(HttpContext, model))
            {
                return RedirectToAction("Index", "Products");
            }

            TempData["ErrorMessage"] = "Tên đăng nhập hoặc mật khẩu không đúng.";
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Customer model)
        {
            if (_accountService.Register(model))
            {
                TempData["SuccessMessage"] = "Đăng ký thành công!";
                return RedirectToAction("Login");
            }

            TempData["ErrorMessage"] = "Tên đăng nhập đã tồn tại.";
            return View(model);
        }

        public IActionResult Logout()
        {
            _accountService.Logout(HttpContext);
            return RedirectToAction("Login");
        }

    }
}
