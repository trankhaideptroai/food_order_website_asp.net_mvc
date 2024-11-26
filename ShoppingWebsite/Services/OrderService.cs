using ShoppingWebsite.Data;
using ShoppingWebsite.Interfaces;
using ShoppingWebsite.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ShoppingWebsite.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Order> GetAllOrders()
        {
            return _context.Orders
                .Select(order => new Order
                {
                    OrderId = order.OrderId,
                    OrderDate = order.OrderDate,
                    Customer = new Customer
                    {
                        FullName = order.Customer.FullName,
                        Address = order.Customer.Address,
                        Phone = order.Customer.Phone
                    },
                    OrderStatus = order.OrderStatus,
                    TotalAmount = order.TotalAmount
                })
                .ToList();
        }
        public List<Order> GetOrdersByDate(string date)
        {
            if (!DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                return new List<Order>();
            }

            return _context.Orders
                .Where(order => order.OrderDate.HasValue && order.OrderDate.Value.Date == parsedDate.Date)
                .Select(order => new Order
                {
                    OrderId = order.OrderId,
                    OrderDate = order.OrderDate,
                    Customer = new Customer
                    {
                        FullName = order.Customer.FullName,
                        Address = order.Customer.Address,
                        Phone = order.Customer.Phone
                    },
                    OrderStatus = order.OrderStatus,
                    TotalAmount = order.TotalAmount
                })
                .ToList();
        }
        public bool UpdateOrderStatus(int orderId, string status)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                return false;
            }

            order.OrderStatus = status;
            _context.SaveChanges();
            return true;
        }
    }
}
