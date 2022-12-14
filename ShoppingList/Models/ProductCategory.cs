using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
