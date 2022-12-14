using ShoppingList.Models;

namespace ShoppingList.Services.ProductCategoryService
{
    public interface IProductCategoryRepository
    {
        public List<ProductCategory> GetAll();
        public ProductCategory GetProductCategoryById(int id);
        public void Insert(ProductCategory product);
        public void Update(ProductCategory product);
        public void Delete(int id);
    }
}
