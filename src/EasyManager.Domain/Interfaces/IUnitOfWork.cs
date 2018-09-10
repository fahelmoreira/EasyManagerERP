using System;
using System.Threading.Tasks;

namespace EasyManager.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits all the changes
        /// </summary>
        Task<bool> Commit();
    }
}