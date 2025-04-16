using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.CategoriesUsesCases
{
    public class ViewSelectedCategoryUsesCase 
    {
        private readonly ICategoryRepository categoryRepository;

        public ViewSelectedCategoryUsesCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Category Execute(int categoryId)
        {
            return categoryRepository.GetCategoryById(categoryId);
        }

       
    }
}
