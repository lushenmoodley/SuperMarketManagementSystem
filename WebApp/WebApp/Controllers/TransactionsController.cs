using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult Index()
        {
            TransactionViewModel transactionViewModel = new TransactionViewModel();
            return View(transactionViewModel);
        }

        public IActionResult Search(TransactionViewModel transVM)
        {
           var transaction= TransactionRepository.Search(transVM.CashierName??string.Empty, transVM.StartDate, transVM.EndDate);

            transVM.Transactions = transaction;

            return View("Index",transVM);
        }
    }
}
