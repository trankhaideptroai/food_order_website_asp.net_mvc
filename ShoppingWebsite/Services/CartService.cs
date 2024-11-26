using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ShoppingWebsite.Data;
using ShoppingWebsite.Interfaces;
using ShoppingWebsite.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingWebsite.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;

        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CartItem> GetCart(HttpContext httpContext)
        {
            var cart = httpContext.Session.GetString("Cart");
            return string.IsNullOrEmpty(cart) ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(cart);
        }

        public bool AddToCart(HttpContext httpContext, int productId)
        {
            var product = _context.Products.Find(productId);
            if (product == null) return false;

            var cart = GetCart(httpContext);
            var cartItem = cart.SingleOrDefault(c => c.ProductId == productId);

            if (cartItem == null)
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = 1
                });
            }
            else
            {
                cartItem.Quantity++;
            }

            httpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
            return true;
        }

        public bool RemoveFromCart(HttpContext httpContext, int productId)
        {
            var cart = GetCart(httpContext);
            var cartItem = cart.SingleOrDefault(c => c.ProductId == productId);

            if (cartItem != null)
            {
                cart.Remove(cartItem);
                httpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
                return true;
            }

            return false;
        }

        public bool UpdateCart(HttpContext httpContext, int productId, int quantity)
        {
            var cart = GetCart(httpContext);
            var cartItem = cart.SingleOrDefault(c => c.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                httpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
                return true;
            }

            return false;
        }

        public bool Checkout(HttpContext httpContext)
        {
            var cart = GetCart(httpContext);
            if (!cart.Any()) return false;

            var customerId = httpContext.Session.GetInt32("CustomerId");
            if (customerId == null) return false;

            var totalAmount = cart.Sum(c => c.Price * c.Quantity);

            var order = new Order
            {
                CustomerId = customerId.Value,
                OrderDate = DateTime.Now,
                TotalAmount = totalAmount,
                OrderStatus = "Pending"
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            foreach (var item in cart)
            {
                _context.OrderDetails.Add(new OrderDetail
                {
                    OrderId = order.OrderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                });
            }

            _context.SaveChanges();
            httpContext.Session.Remove("Cart");
            return true;
        }
    }
}
