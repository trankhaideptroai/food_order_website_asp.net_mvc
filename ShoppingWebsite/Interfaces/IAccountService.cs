using Microsoft.AspNetCore.Http;
using ShoppingWebsite.Models;
using System.Collections.Generic;

namespace ShoppingWebsite.Interfaces
{
    public interface IAccountService
    {
        bool Login(HttpContext httpContext, Customer model);  // Xử lý đăng nhập
        bool Register(Customer model);  // Xử lý đăng ký
        void Logout(HttpContext httpContext);  // Xử lý đăng xuất
        bool IsUserLoggedIn(HttpContext httpContext);  // Kiểm tra trạng thái đăng nhập
        Customer GetCustomerById(int id);  // Lấy thông tin khách hàng theo ID
        IEnumerable<Customer> GetAllCustomers();  // Lấy danh sách toàn bộ khách hàng
    }
}
