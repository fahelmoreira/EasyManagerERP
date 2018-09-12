using EasyManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyManager.Infra.Data.Mapping
{
    public class ManufactureMap : IEntityTypeConfiguration<Manufacture>
    {
        public void Configure(EntityTypeBuilder<Manufacture> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.TradeName)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}