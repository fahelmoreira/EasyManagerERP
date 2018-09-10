using System.Threading.Tasks;
using EasyManager.Domain.Interfaces;

namespace EasyManager.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public bool Commit()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CommitAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}