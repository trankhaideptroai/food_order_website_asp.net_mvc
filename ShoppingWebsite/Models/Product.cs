using System.ComponentModel.DataAnnotations;

namespace ShoppingWebsite.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
       
        
        public int? CategoryId { get; set; }
        //public Category Category { get; set; }
        public string Description { get; set; }


 
    }
}
