using ShoppingWebsite.Models;

namespace ShoppingWebsite.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetAllOrders(); // Lấy tất cả đơn hàng
        List<Order> GetOrdersByDate(string date); // Lấy đơn hàng theo ngày
        bool UpdateOrderStatus(int orderId, string status); // Cập nhật trạng thái đơn hàng
    }
}
