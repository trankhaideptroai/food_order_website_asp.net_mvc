using Microsoft.AspNetCore.Mvc;
using ShoppingWebsite.Interfaces;
using ShoppingWebsite.Models;

namespace ShoppingWebsite.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            var cart = _cartService.GetCart(HttpContext);
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            if (_cartService.AddToCart(HttpContext, productId))
            {
                return RedirectToAction("Index");
            }

            return NotFound();
        }


        [HttpPost]
        public IActionResult UpdateCart(int productId, int quantity)
        {
            if (quantity < 1)
            {
                return BadRequest("Số lượng không hợp lệ.");
            }

            var success = _cartService.UpdateCart(HttpContext, productId, quantity);
            if (success)
            {
                return Json(new { success = true });
            }

            return BadRequest("Không thể cập nhật giỏ hàng.");
        }
        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var success = _cartService.RemoveFromCart(HttpContext, productId);
            if (success)
            {
                var cart = _cartService.GetCart(HttpContext);
                var cartTotal = cart.Sum(item => item.Price * item.Quantity);

                return Json(new { success = true, cartTotal = cartTotal });
            }

            return BadRequest("Không thể xóa sản phẩm.");
        }

        [HttpPost]
        public IActionResult Checkout()
        {
            if (_cartService.Checkout(HttpContext))
            {
                TempData["SuccessMessage"] = "Đặt hàng thành công!";
                return RedirectToAction("OrderSuccess");
            }

            TempData["ErrorMessage"] = "Thanh toán thất bại.";
            return RedirectToAction("Index");
        }
        


        public IActionResult OrderSuccess()
        {
            return View();
        }
    }
}
