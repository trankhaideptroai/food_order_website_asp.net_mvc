using System.ComponentModel.DataAnnotations;

namespace ShoppingWebsite.Models
{
    public class CartDetail
    {
        [Key]
        public int Id { get; set; }

        public int? CartId { get; set; }
        public int? ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        //public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }

}
