using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace SupermarketManagementSystem.Models
{
    public class Product
    {

        public int ProductId { get; set; }

        [Required]
        [Display(Name ="Category")]
        public int Categoryid { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int? Quantity { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double? Price { get; set; }

        public Category? Category { get; set; }





    }
}
