using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace ShoppingList.Models
{
    public class SeedData
    {

        //private readonly ApplicationDbContext _dbContext;

        public void Seed(ApplicationDbContext _dbContext)
        {
            
            _dbContext.Database.Migrate();
        
       
            if (!_dbContext.Categories.Any())
            {
                var categories = new List<ProductCategory>()
                {

                    new ProductCategory
                {
                    CategoryId=1,
                    Name = "Pasta"
                },
                new ProductCategory
                {
                    CategoryId=2,
                    Name = "Dairy"
                },
                new ProductCategory
                {
                    CategoryId=3,
                    Name = "Meat"
                },
                new ProductCategory
                {
                    CategoryId=4,
                    Name = "Vegetables"
                },
                new ProductCategory
                {
                    CategoryId=5,
                    Name = "Fruits"
                },
            };

                _dbContext.Categories.AddRange(categories);
                _dbContext.SaveChanges();
            }

            if (!_dbContext.Products.Any())
            {
                var products = new List<Product>
            {
                new Product
                {

                    ProductName = "Spagetti",
                    Description = "This is spagetti ",
                    CategoryId = 1
               },
                new Product
                {

                    ProductName = "Raviolli",
                    Description = "This is raviolli ",
                    CategoryId = 1
               },

                new Product
                {

                    ProductName = "Taliatelli",
                    Description = "This is taliatelli ",
                    CategoryId = 1
               },

                new Product
                {

                    ProductName = "Milch",
                    Description = "This is milch ",
                    CategoryId = 2
               },

                 new Product
                {

                    ProductName = "Cheese",
                    Description = "This is cheese ",
                    CategoryId = 2
               },
                  new Product
                {

                    ProductName = "Jogurt",
                    Description = "This is jogurt ",
                    CategoryId = 2
               },

                   new Product
                {

                    ProductName = "Pork",
                    Description = "This is pork ",
                    CategoryId = 3
               },
                    new Product
                {

                    ProductName = "Chicken",
                    Description = "This is chicken ",
                    CategoryId = 3
               },
                     new Product
                {

                    ProductName = "Beaf",
                    Description = "This is beaf ",
                    CategoryId = 3
               },

                      new Product
                {

                    ProductName = "Carrot",
                    Description = "This is carrot ",
                    CategoryId = 4
               },

                      new Product
                {

                    ProductName = "Onion",
                    Description = "This is onion ",
                    CategoryId = 4
               },

                      new Product
                {

                    ProductName = "cucumber",
                    Description = "This is cuccumber ",
                    CategoryId = 4
               },

                      new Product
                {

                    ProductName = "Apple",
                    Description = "This is apple ",
                    CategoryId = 5
               },

                      new Product
                {

                    ProductName = "Orange",
                    Description = "This is orange ",
                    CategoryId = 5
               },

                      new Product
                {

                    ProductName = "Banana",
                    Description = "This is banana ",
                    CategoryId = 5
               },
            };
                _dbContext.Products.AddRange(products);
                _dbContext.SaveChanges();
            }
        }
    }
   
}
