using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ShoppingWebsite.Models
{
    public class Order
    {

        public int OrderId { get; set; }          // Khớp với cột OrderId trong bảng
        public int CustomerId { get; set; }        // Khớp với cột CustomerId trong bảng
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        // Khóa ngoại đến Customer
        public Customer Customer { get; set; }

        // Danh sách chi tiết đơn hàng
        //public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
