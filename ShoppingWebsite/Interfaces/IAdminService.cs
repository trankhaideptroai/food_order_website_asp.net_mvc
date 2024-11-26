using ShoppingWebsite.Models;
using System.Collections.Generic;

namespace ShoppingWebsite.Interfaces
{
    public interface IAdminService
    {
        // Customer Management
        Customer GetCustomerById(int id);  // Lấy thông tin khách hàng theo ID
        void AddCustomer(Customer customer);  // Thêm khách hàng mới
        void UpdateCustomer(Customer customer);  // Cập nhật thông tin khách hàng
        bool RemoveCustomer(int id);  // Xóa khách hàng theo ID

        // Product Management
        Product GetProductById(int id);  // Lấy thông tin sản phẩm theo ID
        void AddProduct(Product product);  // Thêm sản phẩm mới
        void UpdateProduct(Product product);  // Cập nhật thông tin sản phẩm
        bool RemoveProduct(int id);  // Xóa sản phẩm theo ID

        // Order Management
        IEnumerable<Order> GetOrderStatistics();  // Lấy danh sách thống kê đơn hàng

        // Common
        IEnumerable<Customer> GetAllCustomers();  // Lấy danh sách tất cả khách hàng
        IEnumerable<Product> GetAllProducts();  // Lấy danh sách tất cả sản phẩm
    }
}
