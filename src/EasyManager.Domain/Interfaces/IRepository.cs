using System;
using System.Linq;
using System.Threading.Tasks;

namespace EasyManager.Domain.Models.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// Adds the object to the entity
        /// </summary>
        /// <param name="obj"></param>
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        Task<int> SaveChanges();
    }
}