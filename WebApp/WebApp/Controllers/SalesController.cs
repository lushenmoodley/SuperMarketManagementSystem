using Microsoft.AspNetCore.Mvc;
using SupermarketManagementSystem.Models;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            var salesViewModel = new SalesViewModel
            {
                Categories = CategoriesRepository.GetCategories()
            };


            return View(salesViewModel);
        }

        public IActionResult SellProductPartial(int productId)
        {
            var product = ProductsRepository.GetProductById(productId);

            return PartialView("_SellProduct", product);
        }
        
        public IActionResult Sell(SalesViewModel salesViewModel)
        {
            if(ModelState.IsValid)
            {
                var prod = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);

                if(prod!=null)
                {
                    TransactionRepository.Add("Cashier 1", salesViewModel.SelectedProductId, prod.Name, prod.Price.HasValue ? prod.Price.Value : 0,
                        prod.Quantity.HasValue ? prod.Quantity.Value : 0, salesViewModel.QuantityToSell);

                    prod.Quantity -= salesViewModel.QuantityToSell;
                    ProductsRepository.UpdateProduct(salesViewModel.SelectedProductId, prod);
                }


            }

            var product = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);

            if(product.Categoryid==null)
            {
                salesViewModel.SelectedCategoryId = 0;
            }
            else
                salesViewModel.SelectedCategoryId = product.Categoryid;

            salesViewModel.Categories = CategoriesRepository.GetCategories();


            return View("Index", salesViewModel);
        }

    }
}
