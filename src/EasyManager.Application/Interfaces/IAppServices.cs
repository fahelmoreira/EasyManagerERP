using System;
using System.Collections.Generic;

namespace EasyManager.Application.Interfaces
{
    public interface IAppServices<T, R>
    {
        void Register(T obj);
        IEnumerable<R> GetAll();
        T GetById(Guid id);
        void Update(T obj);
        void Remove(Guid id);
    }
}