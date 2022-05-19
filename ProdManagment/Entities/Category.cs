namespace ProdManagment.Entities
{
    public class Category
    {
        // [MaxLength(500)]z
        // [Required]
        //  [Column("blog_id")]
        //  [Column(TypeName = "varchar(200)")]
        // [Column(TypeName = "decimal(5, 2)")]
        public int Id { get; set; }
        // rame axali komentari
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

       // public List<CategoryEntity> Categories { get; set; }
    }
}
