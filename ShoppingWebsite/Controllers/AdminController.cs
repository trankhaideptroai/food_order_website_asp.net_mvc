using Microsoft.AspNetCore.Mvc;
using ShoppingWebsite.Interfaces;
using ShoppingWebsite.Models;
using ShoppingWebsite.Services;

namespace ShoppingWebsite.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IOrderService _orderService;

        public AdminController(IAdminService adminService, IOrderService orderService)
        {
            _adminService = adminService;
            _orderService = orderService;
        }

        // Action để trả về trang Dashboard
        public IActionResult Index()
        {
            return View();
        }

        // Action để load quản lý khách hàng (Customer Management)
        [HttpGet]
        public IActionResult LoadCustomerManagement()
        {
            var customers = _adminService.GetAllCustomers();
            if (customers == null || !customers.Any())
            {
                return PartialView("_CustomerManagement", new List<Customer>());
            }
            return PartialView("_CustomerManagement", customers);
        }

        // Action để load quản lý sản phẩm (Product Management)
        [HttpGet]
        public IActionResult LoadProductManagement()
        {
            var products = _adminService.GetAllProducts();
            if (products == null || !products.Any())
            {
                return PartialView("_ProductManagement", new List<Product>());
            }
            return PartialView("_ProductManagement", products);
        }
        // Tạo khách hàng
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _adminService.AddCustomer(customer); // Thêm phương thức trong AdminService
                TempData["SuccessMessage"] = "Thêm khách hàng thành công!";
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // Chỉnh sửa khách hàng



        // Tương tự cho sản phẩm
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _adminService.AddProduct(product); // Thêm phương thức trong AdminService
                TempData["SuccessMessage"] = "Thêm sản phẩm thành công!";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var product = _adminService.GetProductById(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _adminService.UpdateProduct(product);
                TempData["SuccessMessage"] = "Cập nhật sản phẩm thành công!";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult EditCustomer(int id)
        {
            var customer = _adminService.GetCustomerById(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost]
        public IActionResult EditCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _adminService.UpdateCustomer(customer);
                TempData["SuccessMessage"] = "Cập nhật khách hàng thành công!";
                return RedirectToAction("Index");
            }
            return View(customer);
        }
        [HttpPost]
        public IActionResult DeleteCustomer(int id)
        {
            var success = _adminService.RemoveCustomer(id);
            if (success)
            {
                TempData["SuccessMessage"] = "Xóa khách hàng thành công!";
                return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = "Không thể xóa khách hàng.";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            var success = _adminService.RemoveProduct(id);
            if (success)
            {
                TempData["SuccessMessage"] = "Xóa sản phẩm thành công!";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Không thể xóa sản phẩm.";
            return RedirectToAction("Index");
        }
        public IActionResult OrderStatistics()
        {
            var orders = _orderService.GetAllOrders();
            return View(orders);
        }

        // Lấy danh sách đơn hàng theo ngày
        [HttpPost]
        public IActionResult FilterOrdersByDate(string selectedDate)
        {
            var orders = _orderService.GetOrdersByDate(selectedDate);
            return PartialView("_OrderListPartial", orders);
        }

        // Cập nhật trạng thái đơn hàng
        [HttpPost]
        public IActionResult UpdateOrderStatus(int orderId, string status)
        {
            var success = _orderService.UpdateOrderStatus(orderId, status);
            if (success)
            {
                TempData["SuccessMessage"] = "Cập nhật trạng thái đơn hàng thành công!";
            }
            else
            {
                TempData["ErrorMessage"] = "Không thể cập nhật trạng thái đơn hàng.";
            }

            return RedirectToAction("OrderStatistics");
        }

    }
}
