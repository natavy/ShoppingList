using ShoppingList.Models;



namespace ShoppingList.Services.ShoppingListService
{
    public interface IShoppingListRepository
    {

        public List<ShoppingListItem> GetAll();
        public ShoppingListItem GetListItemCategoryById(ShoppingListItem id);
        public void Insert(ShoppingListItem item,int id);
        public void Update(ShoppingListItem item);
        public void Delete(int id);


    }
}
