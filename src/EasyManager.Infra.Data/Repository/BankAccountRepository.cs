using EasyManager.Domain.Interfaces;
using EasyManager.Domain.Models;
using EasyManager.Infra.Data.Context;

namespace EasyManager.Infra.Data.Repository
{
    public class BankAccountRepository : Repository<BankAccount>, IBankAccountRepository
    {
        public BankAccountRepository(EasyManagerContext context) : base(context)
        {
        }
    }
}