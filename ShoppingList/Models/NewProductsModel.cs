using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Models
{
    public class NewProductsModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

    }
}
