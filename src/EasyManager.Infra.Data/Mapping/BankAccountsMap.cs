using EasyManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyManager.Infra.Data.Mapping
{
    public class BankAccountsMap : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}