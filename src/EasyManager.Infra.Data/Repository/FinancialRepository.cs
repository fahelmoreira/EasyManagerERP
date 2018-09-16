using EasyManager.Domain.Interfaces;
using EasyManager.Domain.Models;
using EasyManager.Infra.Data.Context;

namespace EasyManager.Infra.Data.Repository
{
    public class FinancialRepository : Repository<Financial>, IFinancialRepository
    {
        public FinancialRepository(EasyManagerContext context) : base(context)
        {
        }
    }
}