using EasyManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyManager.Infra.Data.Mapping
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");
        }
    }
}