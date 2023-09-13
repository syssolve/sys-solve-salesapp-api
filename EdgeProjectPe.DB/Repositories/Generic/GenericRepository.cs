using System;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using EdgeProjectPe.DB.Context;

namespace EdgeProjectPe.DB.Repositories.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetById(object id);
        Task Insert(T obj);
        void Update(T obj);
        Task Delete(object id);
        void Save();
        void Save(T obj);
        FacturadbContext Context { get; }
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private FacturadbContext _context = null;
        private DbSet<T> _table = null;

        public GenericRepository(FacturadbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public GenericRepository()
        {
            _context = new FacturadbContext();
            _table = _context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _table;
        }

        public async Task<T> GetById(object id)
        {
            return await _table.FindAsync(id);
        }
        public async Task Insert(T obj)
        {
            await _table.AddAsync(obj);
        }
        public void Update(T obj)
        {
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public async Task Delete(object id)
        {
            T existing = await _table.FindAsync(id);
            _table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Save(T obj)
        {
            Insert(obj);
            _context.SaveChanges();
        }
        public FacturadbContext Context { get { return _context; } }
    }
}