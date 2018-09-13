using EasyManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyManager.Infra.Data.Mapping
{
    public class SalesTableMap : IEntityTypeConfiguration<SalesTable>
    {
        public void Configure(EntityTypeBuilder<SalesTable> builder)
        {
        }
    }
}