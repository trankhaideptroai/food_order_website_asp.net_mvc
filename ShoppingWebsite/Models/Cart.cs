using System.ComponentModel.DataAnnotations;

namespace ShoppingWebsite.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }


}
