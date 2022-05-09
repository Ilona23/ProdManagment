using ProdManagment.Interfaces;
using ProdManagment.Models;

namespace ProdManagment.Mapping
{
    public class CategoryMapper : IMapper<Entities.CategoryEntity, Models.CategoryModel>
    {
        public CategoryModel MapFromEntityToModel(Entities.CategoryEntity source) => new CategoryModel
        {
           
            Name = source.Name,
        };

        public Entities.CategoryEntity MapFromModelToEntity(CategoryModel source)
        {
            var entity = new Entities.CategoryEntity();

            MapFromModelToEntity(source, entity);

            return entity;
        }

        public void MapFromModelToEntity(CategoryModel source, Entities.CategoryEntity target)
        {
            target.Name = source.Name;
        }
    }
}
