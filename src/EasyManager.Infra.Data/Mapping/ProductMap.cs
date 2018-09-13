using EasyManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyManager.Infra.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Description)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Cost)
                .IsRequired();

        }
    }
}