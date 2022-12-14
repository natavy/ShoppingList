using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShoppingList.Models;
using System;

namespace ShoppingList.Services.ProductService
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }  
        public List<Product> GetAll()
        {
            return _db.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _db.Products.Find(id);
        }

        public void Insert(Product model)
        {
          
            _db.Add(model);
            _db.SaveChanges();
        }

        public void Update(Product product)
        {
            //_db.Products.Update(product);
            _db.Entry(product).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            Product product = new Product();
            product.ProductId = id;
            var itemToDelete = _db.Products.SingleOrDefault(c => c.ProductId == product.ProductId);

            if (itemToDelete != null)
            {
                _db.Products.Remove(itemToDelete);
                _db.SaveChanges();

            }
        }

        public List<Product> GetProducts(int id)
        {
            var item = _db.Products.Where(i => i.Category.CategoryId == id);
            return item.ToList();
        }
    }
}
