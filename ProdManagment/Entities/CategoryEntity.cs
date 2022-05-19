namespace ProdManagment.Entities
{
    public class CategoryEntity
    {
        // [MaxLength(500)]z
        // [Required]
        //  [Column("blog_id")]
        //  [Column(TypeName = "varchar(200)")]
        // [Column(TypeName = "decimal(5, 2)")]
        public Guid Id { get; set; }
        // rame komentari
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

       // public List<CategoryEntity> Categories { get; set; }
    }
}
