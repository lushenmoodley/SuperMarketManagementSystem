using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.CategoriesUsesCases
{
    public class ViewCategoriesUseCase : IViewCategoriesUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public ViewCategoriesUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> Execute()
        {
            return categoryRepository.GetCategories();
        }

    }
}
