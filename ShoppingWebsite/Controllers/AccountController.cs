using Microsoft.AspNetCore.Mvc;
using ShoppingWebsite.Data;
using ShoppingWebsite.Models; // Đảm bảo bạn đã nhập đúng namespace
using System.Linq;

namespace ShoppingWebsite.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (HttpContext.Session.GetString("Username") != null)
            {
                return RedirectToAction("Index", "Products"); // Chuyển hướng đến trang Products
            }

            return View(); // Nếu chưa đăng nhập, hiển thị view đăng nhập
        }

        [HttpPost]
        public IActionResult Login(Customer model)
        {
            var user = _context.Customers.SingleOrDefault(u => u.Username == model.Username && u.Password == model.Password);
            if (user != null)
            {
                // Lưu thông tin đăng nhập vào session
                HttpContext.Session.SetString("Role", user.Role); // Đảm bảo vai trò được lưu đúng
                HttpContext.Session.SetString("Username", user.Username);
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(7), // Cookie sẽ hết hạn sau 7 ngày 
                };
                Response.Cookies.Append("Username", user.Username, cookieOptions);
                var role = HttpContext.Session.GetString("Role");
                if (!string.IsNullOrEmpty(role) && role.Trim() == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Products");
                }
                
            }

            // Thêm thông báo vào TempData khi đăng nhập thất bại
            TempData["ErrorMessage"] = "Tài khoản hoặc mật khẩu không đúng.";
            return View(model);
        }


        public IActionResult Register()
        {
            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (HttpContext.Session.GetString("Username") != null)
            {
                return RedirectToAction("Index", "Products"); // Chuyển hướng đến trang Products
            }

            return View(); // Nếu chưa đăng nhập, hiển thị view đăng ký
        }

        [HttpPost]
        public IActionResult Register(Customer model)
        {
            var role = "Customer";
            if (ModelState.IsValid)
            {
                // Gán vai trò mặc định là "Customer"
                model.Role = role;

                _context.Customers.Add(model);  // Thêm thông tin khách hàng vào cơ sở dữ liệu
                _context.SaveChanges();  // Lưu thay đổi

                TempData["SuccessMessage"] = "Đăng ký thành công. Vui lòng đăng nhập.";
                return RedirectToAction("Login");
            }

            TempData["ErrorMessage"] = "Đăng ký không thành công. Vui lòng kiểm tra lại.";
            return View(model);
        }
        [HttpGet]
        public IActionResult Logout()
        {
            // Logic đăng xuất
            Response.Cookies.Delete("Username");
            // Xóa session
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Products");
        }
    }
}
