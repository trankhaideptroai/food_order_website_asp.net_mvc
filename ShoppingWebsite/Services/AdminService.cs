using ShoppingWebsite.Data;
using ShoppingWebsite.Interfaces;
using ShoppingWebsite.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingWebsite.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }


        public bool DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public IEnumerable<Order> GetOrderStatistics()
        {
            return _context.Orders
                .Select(o => new Order
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate ?? DateTime.MinValue, // Thay thế NULL bằng giá trị mặc định
                    TotalAmount = o.TotalAmount ?? 0, // Thay thế NULL bằng 0
                    OrderStatus = o.OrderStatus ?? "Unknown" // Thay thế NULL bằng "Unknown"
                })
                .ToList();
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            var existingCustomer = _context.Customers.Find(customer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.Username = customer.Username;
                existingCustomer.Email = customer.Email;
                _context.SaveChanges();
            }
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.Find(id);
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = _context.Products.Find(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                _context.SaveChanges();
            }
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }
        public bool RemoveCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public override bool Equals(object? obj)
        {
            return obj is AdminService service &&
                   EqualityComparer<ApplicationDbContext>.Default.Equals(_context, service._context);
        }
    }
}
