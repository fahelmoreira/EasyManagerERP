using EasyManager.Domain.Interfaces;
using EasyManager.Domain.Models;
using EasyManager.Infra.Data.Context;

namespace EasyManager.Infra.Data.Repository
{
    public class SalesTableRepository : Repository<SalesTable>, ISalesTableRepository
    {
        public SalesTableRepository(EasyManagerContext context) : base(context)
        {
        }
    }
}