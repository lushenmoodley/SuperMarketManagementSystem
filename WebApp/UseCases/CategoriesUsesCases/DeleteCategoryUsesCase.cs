using UseCases.DataStorePluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.CategoriesUsesCases
{
    public class DeleteCategoryUsesCase
    {
        private readonly ICategoryRepository categoryRepository;

        public DeleteCategoryUsesCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }



        public void Execute(int categoryId)
        {
            categoryRepository.DeleteCategory(categoryId);
        }
    }
}
