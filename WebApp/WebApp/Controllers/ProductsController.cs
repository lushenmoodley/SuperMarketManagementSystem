using Microsoft.AspNetCore.Mvc;
using SupermarketManagementSystem.Models;

namespace SupermarketManagementSystem.Controllers
{
    public class ProductsController : Controller
    {


        public IActionResult Index()
        {
            var products = ProductsRepository.GetProducts();
            return View(products);
        }
    }
}
