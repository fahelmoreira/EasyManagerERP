using System;
using System.Threading.Tasks;

namespace EasyManager.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits all the changes asynchronous
        /// </summary>
        Task<bool> CommitAsync();
        /// <summary>
        /// Commits all the changes
        /// </summary>
        /// <returns></returns>
        bool Commit();
    }
}