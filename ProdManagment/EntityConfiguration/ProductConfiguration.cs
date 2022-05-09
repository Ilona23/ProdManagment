using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProdManagment.Entity
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.Package)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.PackageId);

            builder.HasKey(e => e.Id);
            builder.HasOne(b => b.Category);
        }
    }
}
