using CncApp_Final.Data;
using System;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace CncApp_Final.Services
{
    public class EfCrudService<T> : ICrudService<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public DbContext Context => _dbContext;   // ⭐ پیاده‌سازی پراپرتی جدید

        public EfCrudService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public bool HasChanges()
        {
            return _dbContext.ChangeTracker.HasChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Reload(T entity)
        {
            _dbContext.Entry(entity).Reload();
        }

        
    }
}
