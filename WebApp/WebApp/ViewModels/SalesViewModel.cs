﻿using System.ComponentModel.DataAnnotations;
using CoreBusiness;
using WebApp.ViewModels.Validations;

namespace WebApp.ViewModels
{
    public class SalesViewModel
    {
        public int SelectedCategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public int SelectedProductId { get; set; }

        [Display(Name ="Quantitiy")]
        [Range(1,int.MaxValue)]
        [SalesViewModel_EnsurePropertyQuantity]
        public int QuantityToSell { get; set; }

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();


    }
}
