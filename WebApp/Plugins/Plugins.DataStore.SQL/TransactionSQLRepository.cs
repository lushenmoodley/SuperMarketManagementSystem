using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Plugins.DataStore.SQL
{
    public class TransactionSQLRepository:ITransactionRepository
    {
        private readonly MarketContext db;

        public TransactionSQLRepository(MarketContext db)
        {
            this.db = db;
        }

        public void Add(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
        {
            var transaction = new Transaction
            {
                ProductId = productId,
                ProductName = productName,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                CashierName = cashierName
            };

            db.Transactions.Add(transaction);

            db.SaveChanges();
        }

        public IEnumerable<Transaction> GetByDayAndCashier(string cashierName,DateTime startDate, DateTime endDate)
        {
            if(string.IsNullOrWhiteSpace(cashierName))
            {
                return db.Transactions.Where(x => x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date<=endDate);
            }
            else
            {
                return db.Transactions.Where(x =>
                EF.Functions.Like(x.CashierName, $"%{cashierName}%") &&
                x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endDate);
            }

        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime dateTime)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return db.Transactions.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp <= dateTime.Date.AddDays(1).Date);
            }
            else
            {
                return db.Transactions.Where(x => x.CashierName.ToLower().Contains(cashierName.ToLower()) && x.TimeStamp >= startDate.Date && x.TimeStamp <= dateTime.Date.AddDays(1).Date);
            }
        }
    }
}
