using Microsoft.EntityFrameworkCore;
using ProdManagment.Entities;
using ProdManagment.Entity;
using ProdManagment.EntityConfiguration;

namespace ProdManagment
{
    public class ProdManagementContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Package> Packages { get; set; }

        public ProdManagementContext()
        {
        }

        public ProdManagementContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CategoryEntity>()
            //    .HasKey(e => e.Id);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            //modelBuilder.Entity<CategoryEntity>()
            //    .HasMany(b => b.Posts)
            //    .WithOne();

            //modelBuilder.Entity<Post>()
            //    .HasOne(p => p.Blog)
            //    .WithMany(b => b.Posts)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
