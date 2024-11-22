using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters; // Để sử dụng Action Filters
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingWebsite.Data;
using ShoppingWebsite.Models;
using System.Linq;

namespace ShoppingWebsite.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Override OnActionExecuting để kiểm tra Role trước khi thực hiện bất kỳ action nào
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Lấy role từ session
            var role = HttpContext.Session.GetString("Role")?.Trim(); // Sử dụng Trim để loại bỏ khoảng trắng

            // Kiểm tra nếu role không phải là Admin
            if (string.IsNullOrEmpty(role) || role != "Admin")
            {
                // Chuyển hướng đến trang đăng nhập nếu không phải Admin
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }

            base.OnActionExecuting(context);
        }

        // =================== Trang Admin ===================
        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            var products = _context.Products.ToList();
            ViewBag.Customers = customers;
            ViewBag.Products = products;
            return View();
        }

        // =================== Thêm Sản Phẩm ===================
        public IActionResult CreateProduct()
        {
            // Lấy danh sách danh mục từ cơ sở dữ liệu
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product model)
        {
            if (!ModelState.IsValid)
            {
                // Kiểm tra lỗi cụ thể cho CategoryId
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    TempData["ErrorMessage"] += error.ErrorMessage + " ";
                }

                // Lấy lại danh sách danh mục
                ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
                return View(model);
            }

            _context.Products.Add(model);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Thêm sản phẩm thành công.";
            return View();
        }




        // Hiển thị danh sách sản phẩm
        public IActionResult ProductList()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        // =================== Sửa Sản Phẩm ===================
        public IActionResult EditProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // =================== Xóa Sản Phẩm ===================
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        // ==========Thêm khách hàng
        public IActionResult CreateCustomer()
        {
            return View();
        }

        // Xử lý thêm khách hàng vào cơ sở dữ liệu
        [HttpPost]
        public IActionResult CreateCustomer(Customer model)
        {
            if (ModelState.IsValid)
            {
                model.Role = "Customer"; // Gán role là Customer khi thêm khách hàng
                _context.Customers.Add(model); // Thêm khách hàng vào cơ sở dữ liệu
                _context.SaveChanges(); // Lưu thay đổi
                TempData["SuccessMessage"] = "Thêm khách hàng thành công.";
                return RedirectToAction("CustomerList"); // Chuyển hướng đến danh sách khách hàng
            }

            TempData["ErrorMessage"] = "Thêm khách hàng không thành công. Vui lòng kiểm tra lại.";
            return View(model);
        }

        // Hiển thị danh sách khách hàng
        public IActionResult CustomerList()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        // Sửa khách hàng
        public IActionResult EditCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult EditCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Update(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // Xóa khách hàng
        public IActionResult DeleteCustomer(int id)
        {
            bool hasOrders = _context.Orders.Any(o => o.CustomerId == id);
            if (hasOrders)
            {
                TempData["ErrorMessage"] = "Không thể xóa khách hàng vì vẫn còn đơn hàng liên quan.";
                return View("Index");
            }
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Khách hàng đã được xóa thành công.";
            }
            return RedirectToAction("Index");
        }
        public IActionResult OrderStatistics()
        {
            // Kiểm tra Role Admin
            var role = HttpContext.Session.GetString("Role");
            if (role == null || role.Trim() != "Admin")
            {
                return RedirectToAction("Index", "Products");
            }

            var orders = _context.Orders
                .Include(o => o.Customer)
                .ToList();
            return View(orders);
        }
        [HttpPost]
        public IActionResult UpdateOrderStatus(int orderId, string status)
        {
            var order = _context.Orders.Find(orderId);
            if (order != null)
            {
                order.OrderStatus = status;
                _context.SaveChanges();
            }
            return RedirectToAction("OrderStatistics");
        }
        public IActionResult LoadCustomerManagement()
        {
            var customers = _context.Customers.ToList();
            return PartialView("_CustomerManagement", customers);
        }

        public IActionResult LoadProductManagement()
        {
            var products = _context.Products.ToList();
            return PartialView("_ProductManagement", products);
        }

    }
}
