using Microsoft.EntityFrameworkCore;

namespace ShoppingList.Models
{

    public class CategoryItem
    {
        public List<Product>Products { get; set; }  
        public ProductCategory Category { get; set; }

    }
}
