using Microsoft.EntityFrameworkCore;
using ShoppingList.Models;

namespace ShoppingList.Services.ProductCategoryService
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {

        private readonly ApplicationDbContext _db;

        public ProductCategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<ProductCategory> GetAll()
        {
            return _db.Categories.ToList();
        }

        public ProductCategory GetProductCategoryById(int id)
        {
            return GetAll().FirstOrDefault(category => category.CategoryId == id);
        }

        public void Insert(ProductCategory category)
        {
            _db.Add(category);
            _db.SaveChanges();
        }

        public void Update(ProductCategory category)
        {
            _db.Entry(category).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            ProductCategory category = new ProductCategory();
            category.CategoryId = id;
            var itemToDelete = _db.Categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);

            if (itemToDelete != null)
            {
                _db.Categories.Remove(itemToDelete);
                _db.SaveChanges();

            }
        }
    }
}
