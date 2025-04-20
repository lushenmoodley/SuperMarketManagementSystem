using Microsoft.AspNetCore.Mvc;
using UseCases.Interfaces;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ISearchTransactionsUseCase searchTransactionsUseCase;

        public TransactionsController(ISearchTransactionsUseCase searchTransactionsUseCase)
        {
            this.searchTransactionsUseCase = searchTransactionsUseCase;
        }

        public IActionResult Index()
        {
            TransactionViewModel transactionsViewModel = new TransactionViewModel();
            return View(transactionsViewModel);
        }


        public IActionResult Search(TransactionViewModel transVM)
        {
            var transactions = searchTransactionsUseCase.Execute(
              transVM.CashierName ?? string.Empty,
              transVM.StartDate,
              transVM.EndDate);

            transVM.Transactions = transactions.ToList();

            return View("Index", transVM);

        }
    }
}
