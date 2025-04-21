using Microsoft.AspNetCore.Mvc;
using UseCases.Interfaces;
using WebApp.Models;

namespace WebApp.ViewComponents
{
    [ViewComponent]
    public class TransactionViewComponent : ViewComponent
    {
        private readonly IGetTodayTransactionsUseCase GetTodayTransactionsUseCase;

        public TransactionViewComponent(IGetTodayTransactionsUseCase GetTodayTransactionsUseCase)
        {
            this.GetTodayTransactionsUseCase = GetTodayTransactionsUseCase;
        }

        public IViewComponentResult Invoke(string Username)
        {
            var transaction = GetTodayTransactionsUseCase.Execute(Username);

            return View(transaction);
        }

    }
}