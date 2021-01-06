using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private bool _disposed;

        private readonly OrderContext _context;

        public BaseRepository(OrderContext context)
        {
            _context = context;
        }
        
        public virtual IEnumerable<TEntity> List()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual void Create(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
        }

        public virtual void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            var item = _context.Set<TEntity>().Find(id);
            if (item != null)
                _context.Set<TEntity>().Remove(item);

        }

        public void Save()
        {
            _context.SaveChanges();
        }
        
        public void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                _context.Dispose();
            _disposed = true;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
