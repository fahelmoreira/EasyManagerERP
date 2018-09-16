using EasyManager.Domain.Interfaces;
using EasyManager.Domain.Models;
using EasyManager.Infra.Data.Context;

namespace EasyManager.Infra.Data.Repository
{
    public class DepartamentRepository : Repository<Departament>, IDepartamentRepository
    {
        public DepartamentRepository(EasyManagerContext context) : base(context)
        {
        }
    }
}