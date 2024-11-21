namespace ShoppingWebsite.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // Khóa ngoại đến đơn hàng và sản phẩm
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
