using Microsoft.EntityFrameworkCore;
using ShoppingList.Models;
using ShoppingList.Services.ProductCategoryService;
using ShoppingList.Services.ProductService;
using ShoppingList.Services.ShoppingListService;

namespace ShoppingList.Services.ShoppingListService
{
    public class ShoppingListRepository : IShoppingListRepository
    {

        private readonly ApplicationDbContext _db;

        public const string ListSessionKey = "Id";
        public ShoppingListRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Delete(int id)
        {
           

            ShoppingListItem item = new ShoppingListItem();
            item.Id = id;
            var itemToDelete = _db.ShoppingCartItems.SingleOrDefault(c => c.Id == item.Id);


            if (itemToDelete != null)
            {
                _db.ShoppingCartItems.Remove(itemToDelete);
                _db.SaveChanges();

            }
        }


        public List<ShoppingListItem> GetAll()
        {

            return _db.ShoppingCartItems.ToList();
        }

        public ShoppingListItem GetListItemCategoryById(ShoppingListItem id)
        {
            return _db.ShoppingCartItems.Find(id);
        }

        
        public void Insert(ShoppingListItem item,int id)
        {

            var pId = _db.Products.Find(id);


            ShoppingListItem listItem = GetAll().Where(x => x.ProductId == id).FirstOrDefault();

            if (listItem == null)
            {
                ShoppingListItem list = new ShoppingListItem()
                {
                    Product = pId,
                    Quantity = 1,
                    ProductName = item.ProductName


                };
                _db.Add(list);
            }
            else
            {
                listItem.Quantity++;
               
            }
           
            _db.SaveChanges();
        }

       

        public void Update(ShoppingListItem item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }



        public ShoppingListItem GetListById(int id)
        {
            return _db.ShoppingCartItems.Find(id);
        }


       

    }
}
