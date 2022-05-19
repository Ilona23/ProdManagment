using System.ComponentModel.DataAnnotations;

namespace ProdManagment.Entity
{
    public class Package
    {
        public Package()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Product> Products { get; set; }
        public string Description { get; set; }
    }
}
