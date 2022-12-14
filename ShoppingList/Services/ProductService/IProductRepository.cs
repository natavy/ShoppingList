using ShoppingList.Models;

namespace ShoppingList.Services.ProductService
{
    public interface IProductRepository
    {

        public List<Product> GetAll();
        public Product GetProductById(int id);
        public void Insert(Product product);    
        public void Update(Product product);
        public void Delete(int id);
        List<Product> GetProducts(int id);
    }
}
