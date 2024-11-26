using ShoppingWebsite.Models;
using System.Collections.Generic;

namespace ShoppingWebsite.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(string searchString, string sortOrder);  // Lấy danh sách sản phẩm với tìm kiếm và sắp xếp
        Product GetProductById(int id);  // Lấy thông tin chi tiết sản phẩm theo ID
        bool UpdateProduct(Product product);  // Cập nhật thông tin sản phẩm
        bool DeleteProduct(int id);  // Xóa sản phẩm
    }
}
