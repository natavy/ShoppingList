using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShoppingList.Models;
using ShoppingList.Services.ProductCategoryService;
using ShoppingList.Services.ProductService;
using ShoppingList.Services.ShoppingListService;

namespace ShoppingList.Controllers
{
    public class ListController : Controller
    {
        
        public const string ListSessionKey = "Id";
        private readonly IShoppingListRepository _listRepository;
        private readonly IProductRepository _repositoryProduct;
        private readonly IProductCategoryRepository _repositoryProductCategory;
        public ListController(IShoppingListRepository listRepository, IProductRepository repositoryProduct, IProductCategoryRepository repositoryProductCategory)
        {
            _listRepository = listRepository;
            _repositoryProduct = repositoryProduct;
            _repositoryProductCategory = repositoryProductCategory;
    }

        public IActionResult Index()
        {
            return View(_listRepository.GetAll());

        }


        public IActionResult Create(ShoppingListItem model,int id)
        {
           

                _listRepository.Insert(model, id);
                  return RedirectToAction("Index", "Home");


        }


        //ListItem with session...it is not ready
        public string GetListId()
        {

            var s = HttpContext.Session.GetString(ListSessionKey);
            var i = HttpContext.Session.GetString(User.Identity.Name);
            if (string.IsNullOrEmpty(s))
            {
                if (!string.IsNullOrWhiteSpace(i))
                {
                    s = i;
                }
                else
                {
                    
                    Guid tempCartId = Guid.NewGuid();
                    s = tempCartId.ToString();
                }
            }
            return s.ToString();
        }

       

        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            _listRepository.Delete(id);
            return RedirectToAction("Index");
        }


        [HttpPost]

        public ActionResult Delete(int id, ShoppingListItem item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _listRepository.Delete(id);


                }
                catch (Exception ex)
                {

                    return Json(ex.Message);
                }

            }

           
            return RedirectToAction("Index");

        }
    }
}
