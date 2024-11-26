using Microsoft.AspNetCore.Http;
using ShoppingWebsite.Data;
using ShoppingWebsite.Interfaces;
using ShoppingWebsite.Models;
using System.Linq;

namespace ShoppingWebsite.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;

        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Login(HttpContext httpContext, Customer model)
        {
            var user = _context.Customers.SingleOrDefault(u => u.Username == model.Username && u.Password == model.Password);
            if (user != null)
            {
                httpContext.Session.SetString("Username", user.Username);
                httpContext.Session.SetInt32("CustomerId", user.Id);

                // Lấy Role từ cơ sở dữ liệu và lưu vào session
                httpContext.Session.SetString("Role", user.Role);

                return true;
            }
            return false;
        }

        public bool Register(Customer model)
        {
            if (_context.Customers.Any(c => c.Username == model.Username))
            {
                return false;
            }

            // Đặt Role mặc định cho người dùng mới
            model.Role = "Customer";
            _context.Customers.Add(model);
            _context.SaveChanges();
            return true;
        }

        public void Logout(HttpContext httpContext)
        {
            httpContext.Session.Clear();
        }

        public bool IsUserLoggedIn(HttpContext httpContext)
        {
            return !string.IsNullOrEmpty(httpContext.Session.GetString("Username"));
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.Find(id);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }
    }
}
