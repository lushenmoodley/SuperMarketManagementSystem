﻿using System.ComponentModel.DataAnnotations;
using CoreBusiness;

namespace WebApp.ViewModels
{
    public class TransactionViewModel
    {
        [Display(Name = "Cashier Name")]
        public string? CashierName { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Today;

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; } = DateTime.Today;

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
