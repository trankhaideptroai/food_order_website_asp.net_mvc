namespace ShoppingWebsite.Models
{
    public class Cart
    {

        public int Id { get; set; }
        public string CustomerId { get; set; }  // Đảm bảo đây là CustomerId duy nhất
        public List<CartItem> CartItems { get; set; }
    public decimal TotalPrice => CartItems.Sum(item => item.Price * item.Quantity);
    }

}
