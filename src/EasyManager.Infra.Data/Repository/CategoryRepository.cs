using EasyManager.Domain.Interfaces;
using EasyManager.Domain.Models;
using EasyManager.Infra.Data.Context;

namespace EasyManager.Infra.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICaregoryRepository
    {
        public CategoryRepository(EasyManagerContext context) : base(context)
        {
        }
    }
}