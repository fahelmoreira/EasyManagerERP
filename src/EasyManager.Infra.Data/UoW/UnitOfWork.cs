using System.Threading.Tasks;
using EasyManager.Domain.Interfaces;
using EasyManager.Infra.Data.Context;

namespace EasyManager.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EasyManagerContext _context;

        public UnitOfWork(EasyManagerContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> CommitAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}