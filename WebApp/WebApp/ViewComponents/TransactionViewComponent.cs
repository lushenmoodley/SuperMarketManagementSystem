using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.ViewComponents
{
    [ViewComponent]
    public class TransactionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string Username)
        {
            var transaction = TransactionRepository.GetByDayAndCashier(Username, DateTime.Now);

            return View(transaction);
        }

    }
}