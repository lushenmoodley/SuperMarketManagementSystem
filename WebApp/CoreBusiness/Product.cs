﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [Display(Name ="Category")]
        public int? CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double? Price { get; set; }

        public Category? Category { get; set; }
    }
}
