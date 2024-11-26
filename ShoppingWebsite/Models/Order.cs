using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ShoppingWebsite.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalAmount { get; set; }

        [Required]
        public DateTime? OrderDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string OrderStatus { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        // Foreign Key Relations (Optional, if needed)
        public virtual Customer Customer { get; set; }
    }

}
