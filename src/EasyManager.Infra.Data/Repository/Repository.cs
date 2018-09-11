using System;
using System.Linq;
using System.Threading.Tasks;
using EasyManager.Domain.Interfaces;
using EasyManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyManager.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly EasyManagerContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(EasyManagerContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj) => DbSet.Add(obj);

        public virtual TEntity GetById(Guid id) => DbSet.Find(id);

        public virtual IQueryable<TEntity> GetAll() => DbSet;

        public virtual void Update(TEntity obj) => DbSet.Update(obj);

        public virtual void Remove(Guid id) => DbSet.Remove(DbSet.Find(id));

        public int SaveChanges() => Db.SaveChanges();
        public async Task<int> SaveChangesAsync() => await Db.SaveChangesAsync();
        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}