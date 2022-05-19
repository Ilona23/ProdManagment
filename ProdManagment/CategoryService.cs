using Microsoft.EntityFrameworkCore;
using ProdManagment.Interfaces;
using ProdManagment.Mapping;
using ProdManagment.Models;

namespace ProdManagment
{
    public class CategoryService : ICategoryService
    {
        private readonly ProdManagementContext _context;
        private readonly IMapper<ProdManagment.Entities.Category, ProdManagment.Models.CategoryModel> _categoryMapper;

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

        public GetCategoryResponse GetCategory(GetCategoryRequest getCategoryRequest)
        {
            var category = _context.Categories.Find(getCategoryRequest.Id);

            return new GetCategoryResponse { Category = _categoryMapper.MapFromEntityToModel(category)};
        }

        public DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest deleteCategoryRequest)
        {
            var categoryToDelete = _context.Categories.Find(deleteCategoryRequest.Id);
            if (categoryToDelete == null) 
            {
                throw new DbUpdateException($"Category with id '{deleteCategoryRequest.Id}' doesn't exist.");
            }

            // _context.Categories.RemoveRange(_context.Categories);

            _context.Categories.Remove(categoryToDelete);
            _context.SaveChanges();

            return new DeleteCategoryResponse();
        }

        public UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest updateCategoryRequest)
        {
           
            var existingCategoryToUpdate = _context.Categories.Single(_ => _.Id == updateCategoryRequest.Id);

            if (existingCategoryToUpdate == null)
            {
                throw new ArgumentException($"Category with Id {updateCategoryRequest.Id} does not exist ", nameof(existingCategoryToUpdate));
            }

            var category = new CategoryModel
            {
                Id = updateCategoryRequest.Id,
                Code = updateCategoryRequest.Code,
                Name = updateCategoryRequest.Name,
                Description = updateCategoryRequest.Description,
            };

            //existingCategoryToUpdate.Id = updateCategoryRequest.Id;
            //existingCategoryToUpdate.Code = updateCategoryRequest.Code;
            //existingCategoryToUpdate.Name = updateCategoryRequest.Name;
            //existingCategoryToUpdate.Description = updateCategoryRequest.Description;

            _categoryMapper.MapFromModelToEntity(category, existingCategoryToUpdate);

            // set Modified flag in your entry
            // _context.Entry(categoryEntityToUpdate).State = EntityState.Detached;
            //_context.Entry(existingCategoryToUpdate).CurrentValues.SetValues(existingCategoryToUpdate);

            // var category = _categoryMapper.MapFromEntityToModel(existingCategoryToUpdate);

           // _context.Update(categoryEntityToUpdate);
            _context.SaveChanges();
            return new UpdateCategoryResponse{ UpdatedCategory = category};
        }
    }
}
