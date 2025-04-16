using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoreBusiness
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public  List<Product> Products { get; set; }
    }
}
