using EasyManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyManager.Infra.Data.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");
        }
    }
}