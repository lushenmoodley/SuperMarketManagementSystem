﻿using CoreBusiness;
namespace SupermarketManagementSystem.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public Product Product { get; set; } = new Product();
    }
}
