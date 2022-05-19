using ProdManagment.Models;

namespace ProdManagment.Interfaces
{
    public interface ICategoryService
    {
        GetCategoryResponse GetCategory(GetCategoryRequest request);

        CreateCategoryResponse CreateCategory(CategoryModel request);

        DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest request);

        UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest request);

    }
}
