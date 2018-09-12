using System;
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
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (System.Exception ex)
            {
                Console.Write(ex);
                return false;
            }
        }

        public async Task<bool> CommitAsync()
        {
            try
            {
                return (await _context.SaveChangesAsync()) > 0; 
            }
            catch (System.Exception ex)
            {
                Console.Write(ex);
                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}