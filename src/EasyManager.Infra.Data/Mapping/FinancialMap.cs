using EasyManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyManager.Infra.Data.Mapping
{
    public class FinancialMap : IEntityTypeConfiguration<Financial>
    {
        public void Configure(EntityTypeBuilder<Financial> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");
        }
    }
}