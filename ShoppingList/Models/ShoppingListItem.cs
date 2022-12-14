using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models
{
    public class ShoppingListItem
    {
      
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        
    }
}
