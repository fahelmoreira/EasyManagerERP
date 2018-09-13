using EasyManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyManager.Infra.Data.Mapping
{
    public class CredcardOperatorMap : IEntityTypeConfiguration<CredcardOperator>
    {
        public void Configure(EntityTypeBuilder<CredcardOperator> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");
        }
    }
}