﻿namespace WebApp.Models
{
    public static class TransactionRepository
    {
        private static List<Transaction> transactions=new List<Transaction>();

        public static IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date)
        {
            //if (string.IsNullOrEmpty(cashierName))
            //{
            //    return transactions.Where(x => x.TimeStamp.Date == date.Date);
            //}
            //else
            //{
            //    return transactions.Where(x =>
            //        x.CashierName.ToLower().Contains(cashierName.ToLower()) &&
            //        x.TimeStamp.Date == date.Date
            //    );
            //}

            return transactions.Where(x => x.CashierName.ToLower().Contains(cashierName.ToLower()) && x.TimeStamp.Date == date.Date);

        }

        public static IEnumerable<Transaction> Search(string cashierName,DateTime startDate,DateTime endDate)
        {
            if(string.IsNullOrWhiteSpace(cashierName))
            {
                return transactions.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
            }
            else
            {
                return transactions.Where(x => x.CashierName.ToLower().Contains(cashierName.ToLower()) && x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
            }
        }

        public static void Add(String casheierName,int productId,string productName,double price,int beforeQty,int soldQty)
        {
            var transaction = new Transaction
            {
                ProductId = productId,
                ProductName = productName,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                CashierName = casheierName
            };

            if(transactions !=null && transactions.Count>0)
            {
                var maxId = transactions.Max(x => x.TransactionId);
                transaction.TransactionId = maxId + 1;
            }
            else
            {
                transaction.TransactionId = 1;
            }
            transactions?.Add(transaction);
        }

    }
}
