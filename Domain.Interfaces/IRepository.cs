using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> List();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
