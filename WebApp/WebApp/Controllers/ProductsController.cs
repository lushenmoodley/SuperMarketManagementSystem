using Microsoft.AspNetCore.Mvc;
using SupermarketManagementSystem.Models;
using SupermarketManagementSystem.ViewModels;
using WebApp.Models;

namespace SupermarketManagementSystem.Controllers
{
    public class ProductsController : Controller
    {


        public IActionResult Index()
        {
            var products = ProductsRepository.GetProducts(loadCategory:true);
            return View(products);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            var productViewModel = new ProductViewModel
            {
                Categories = CategoriesRepository.GetCategories()
            };

            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
           

            if(ModelState.IsValid)
            {
                ProductsRepository.AddProduct(productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "Add";
            productViewModel.Categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var productViewModel = new ProductViewModel
            {
                Product = ProductsRepository.GetProductById(id) ?? new Product(),
                Categories = CategoriesRepository.GetCategories()
            };
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.UpdateProduct(productViewModel.Product.ProductId, productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "Edit";
            productViewModel.Categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
        }

        public IActionResult Delete(int id)
        {
            ProductsRepository.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProductsByCategoryPartial(int CategoryId)
        {
            var products = ProductsRepository.GetProductsByCategoryId(CategoryId);

            return PartialView("_Products", products);
        }
    }
}
