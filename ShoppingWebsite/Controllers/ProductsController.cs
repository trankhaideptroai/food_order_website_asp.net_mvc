using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using ShoppingWebsite.Data;
using ShoppingWebsite.Models;
using System.Linq;

namespace ShoppingWebsite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString, string sortOrder)
        {
            // Kiểm tra xem người dùng đã đăng nhập chưa
            ViewData["IsProductIndex"] = true;

            var products = _context.Products.AsQueryable();
            // Kiểm tra vai trò của người dùng

            switch (sortOrder)
            {
                case "price_asc":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
            }
            // Thiết lập số lượng sản phẩm trong giỏ hàng
            SetCartItemCount();

            // Logic tìm kiếm sản phẩm
            
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString) || p.Price.ToString().Contains(searchString));
            }

            return View(products.ToList());
        }




        public IActionResult Details(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);

        }
        private void SetCartItemCount()
        {
            var cart = HttpContext.Session.GetString("Cart");
            var cartItems = string.IsNullOrEmpty(cart)
                ? new List<CartItem>()
                : JsonConvert.DeserializeObject<List<CartItem>>(cart);

            ViewBag.CartItemCount = cartItems.Sum(c => c.Quantity);
        }
    }
}
