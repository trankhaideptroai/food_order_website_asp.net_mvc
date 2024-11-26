using Microsoft.AspNetCore.Http;
using ShoppingWebsite.Models;
using System.Collections.Generic;

namespace ShoppingWebsite.Interfaces
{
    public interface ICartService
    {
        List<CartItem> GetCart(HttpContext httpContext); // Lấy giỏ hàng
        bool AddToCart(HttpContext httpContext, int productId); // Thêm sản phẩm vào giỏ hàng
        bool RemoveFromCart(HttpContext httpContext, int productId); // Xóa sản phẩm khỏi giỏ hàng
        bool UpdateCart(HttpContext httpContext, int productId, int quantity); // Cập nhật số lượng sản phẩm
        bool Checkout(HttpContext httpContext); // Thanh toán
    }
}
