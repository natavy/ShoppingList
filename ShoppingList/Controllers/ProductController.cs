using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShoppingList.Models;
using ShoppingList.Services.ProductCategoryService;
using ShoppingList.Services.ProductService;

namespace ShoppingList.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repositoryProduct;
        private readonly IProductCategoryRepository _repositoryProductCategory;
        private readonly ApplicationDbContext _db;
        public ProductController(IProductRepository repositoryProduct, ApplicationDbContext db, IProductCategoryRepository repositoryProductCategory)
        {
            _repositoryProduct = repositoryProduct;
            _repositoryProductCategory = repositoryProductCategory;
            _db = db;
        }

        public IActionResult Index()
        {
            
            var records = _repositoryProduct.GetAll();
            return View(records);
        }



        //Get
        public IActionResult Create(int categoryId)
        {

            GetCategoriesForDropDownList();
            NewProductsModel model = new NewProductsModel
            {
                CategoryId = categoryId
            };

            return View(model);
        }


        // POST
        [HttpPost]
        public IActionResult Create( int categoryId, NewProductsModel model)
        {
            //var getProductId = _repositoryProduct.GetProductById(productId);
            var category = _repositoryProductCategory.GetProductCategoryById(categoryId);
           
            Product product = new Product
            {
                //ProductId=getProductId,
                ProductName=model.Name,
                Description=model.Description,
                Category=category
                
                
            };

            _repositoryProduct.Insert(product);

            return RedirectToAction("GetProducts", "Home", new { id = categoryId});

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            GetCategoriesForDropDownList();
            var product= _repositoryProduct.GetProductById(id);
            NewProductsModel model = new NewProductsModel();

            model.CategoryId = product.Category.CategoryId;
            model.Name = product.ProductName;
            model.Description = product.Description;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(NewProductsModel model, int categoryId,int id)
        {
            var category = _repositoryProductCategory.GetProductCategoryById(categoryId);
            var item = _repositoryProduct.GetProductById(id);
            item.Category = category;
            item.ProductName = model.Name;
            item.Description = model.Description;
            _repositoryProduct.Update(item);
            return RedirectToAction("GetProducts", "Home", new { id = categoryId });

        }


        public ActionResult Delete(int id,int categoryId)
        {
           _repositoryProductCategory.GetProductCategoryById(categoryId);

            if (id == 0)
            {
                return NotFound();
            }

            _repositoryProduct.Delete(id);
            return RedirectToAction("GetProducts", "Home", new { id = categoryId });
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product product, int categoryId)
        {
           _repositoryProductCategory.GetProductCategoryById(categoryId);

            _repositoryProduct.Delete(id);
            return RedirectToAction("GetProducts", "Home", new { id = categoryId });


        }


        private void GetCategoriesForDropDownList()
        {
            var categories = _repositoryProductCategory.GetAll().Select(c => new ProductCategory
            {
                CategoryId = c.CategoryId,
                Name = c.Name
            });
            ViewBag.Categories = new SelectList(categories, "CategoryId", "Name");
        }
    }
}
