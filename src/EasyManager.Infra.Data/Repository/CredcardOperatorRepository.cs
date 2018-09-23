using EasyManager.Domain.Interfaces;
using EasyManager.Domain.Models;
using EasyManager.Infra.Data.Context;

namespace EasyManager.Infra.Data.Repository
{
    public class CredcardOperatorRepository : Repository<CredcardOperator>, ICredcardOperatorRepository
    {
        public CredcardOperatorRepository(EasyManagerContext context) : base(context)
        {
        }
    }
}