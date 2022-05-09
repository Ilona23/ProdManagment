using ProdManagment.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProdManagment.Entity
{
    public class Product
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public CategoryEntity Category { get; set; }
        public Guid PackageId { get; set; }
        public Package Package { get; set; }
        public string Description { get; set; }
    }
}
