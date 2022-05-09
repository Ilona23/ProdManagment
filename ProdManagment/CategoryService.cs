using Microsoft.EntityFrameworkCore;
using ProdManagment.Interfaces;
using ProdManagment.Mapping;
using ProdManagment.Models;

namespace ProdManagment
{
    public class CategoryService : ICategoryService
    {
        private readonly ProdManagementContext _context;
        private readonly IMapper<ProdManagment.Entities.CategoryEntity, ProdManagment.Models.CategoryModel> _categoryMapper;

        public CategoryService(ProdManagementContext context)
        {
            _categoryMapper = new CategoryMapper();
            _context = context;
        }

        public CreateCategoryResponse CreateCategory(CategoryModel category)
        {
            var categoryAlreadyExists = _context.Categories.Any(p => p.Id == category.Id);

            if (categoryAlreadyExists)
            {
                throw new DbUpdateException($"Category with id '{category.Id}' already exist.");
            }

            var record = _context.Categories.Add(_categoryMapper.MapFromModelToEntity(category));

            _context.SaveChanges();

            return new CreateCategoryResponse {CreatedCategory = _categoryMapper.MapFromEntityToModel(record.Entity)};

        }
    }
}
