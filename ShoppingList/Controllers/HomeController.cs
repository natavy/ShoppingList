using Microsoft.AspNetCore.Mvc;
using ShoppingList.Models;
using ShoppingList.Services.ProductCategoryService;
using ShoppingList.Services.ProductService;
using System.Diagnostics;

namespace ShoppingList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private readonly IProductCategoryRepository _repositoryProductCategory;
        private readonly IProductRepository _repositoryProduct;
        
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, IProductCategoryRepository repositoryProductCategory, IProductRepository repositoryProduct)
        {
            _logger = logger;
            _repositoryProductCategory = repositoryProductCategory;
            _repositoryProduct = repositoryProduct;
            
        }

        public IActionResult Index()
        {
             var records= _repositoryProductCategory.GetAll();
            return View(records);
        }


        public IActionResult AddOrEdit()
        {

            var records = _repositoryProductCategory.GetAll();
            return View(records);
        }

        //Get
        public IActionResult Create()
        {

            return View();
        }

        // POST
        [HttpPost]
        public IActionResult Create(ProductCategory category)
        {

            _repositoryProductCategory.Insert(category);
             return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            return View(_repositoryProductCategory.GetProductCategoryById(id));
        }

        [HttpPost]
        public IActionResult Edit(ProductCategory category)
        {
            _repositoryProductCategory.Update(category);
             return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            _repositoryProductCategory.Delete(id);
            return RedirectToAction("Index");
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductCategory category)
        {
            _repositoryProductCategory.Delete(id);
             return RedirectToAction("Index");

          }


        public IActionResult GetProducts(int id)
        {
            var category = _repositoryProductCategory.GetProductCategoryById(id);
            var productId = _repositoryProduct.GetProducts(id);

            var productListings = productId.Select(pr => new Product
            {
                ProductId = pr.ProductId,
                ProductName = pr.ProductName,
            });

            var model = new CategoryItem
            {
                Category = category,
                Products = productId
            };

            return View(model);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}