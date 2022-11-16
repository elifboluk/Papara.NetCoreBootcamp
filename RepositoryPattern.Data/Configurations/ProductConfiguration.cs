using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryPattern.Domain.Entities;

// IEntityTypeConfiguration: DbSet'i tablo yapmak ve configure etmek için kullandığımız class'tır. Property ilişkileri belirlenir. 
namespace RepositoryPattern.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            // builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Barcode).IsRequired(); // Barkod alanı boş geçilemez.                        
            builder.ToTable("Products"); // Class'ın tablo olduğunu belirler.
        }
    }
}
