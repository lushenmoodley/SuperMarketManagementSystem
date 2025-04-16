using System.ComponentModel.DataAnnotations;
using SupermarketManagementSystem.Models;
using SupermarketManagementSystem.ViewModels;

namespace WebApp.ViewModels.Validations
{
    public class SalesViewModel_EnsurePropertyQuantity:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var salesViewModel = validationContext.ObjectInstance as SalesViewModel;
            
             if(salesViewModel!=null)
            {
                if (salesViewModel.QuantityToSell <= 0)
                {
                    return new ValidationResult("The quantitiy to sell has to be greater than zero");
                }
                else
                {
                    var product = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);

                    if (product != null)
                    {
                        if (product.Quantity < salesViewModel.QuantityToSell)
                        {
                            return new ValidationResult($"{product.Name} only has {product.Quantity} left. It is not enough");
                        }
                      
                    }
                }
            }
          

                return ValidationResult.Success;
        }
    }
    
}
