// مسیر: Services/EfListService.cs
using CncApp_Final.Data;
using System;
using System.ComponentModel;
using System.Data.Entity;

namespace CncApp_Final.Services
{
    //public class EfListService<T> : IListService where T : class
    //{
    //    protected readonly AppDbContext DbContext;
    //    protected readonly DbSet<T> DbSet;

    //    public EfListService(AppDbContext dbContext)
    //    {
    //        DbContext = dbContext;
    //        DbSet = dbContext.Set<T>();
    //    }

    //    public virtual IBindingList GetAll()
    //    {
    //        DbSet.Load();
    //        var z = DbSet.Local.ToBindingList();
    //        return DbSet.Local.ToBindingList();
    //    }

    //    public void DeleteById(int id)
    //    {
    //        var entity = DbSet.Find(id);
    //        if (entity != null)
    //        {
    //            DbSet.Remove(entity);
    //            DbContext.SaveChanges();
    //        }
    //    }
    //}


    public class EfListService<T> : IListService where T : class
    {
        private readonly Func<AppDbContext> _dbContextFactory;

        public EfListService(Func<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public virtual IBindingList GetAll()
        {
            var dbContext = _dbContextFactory();
            var dbSet = dbContext.Set<T>();
            dbSet.Load();
            return dbSet.Local.ToBindingList();
        }

        public void DeleteById(int id)
        {
            using (var dbContext = _dbContextFactory())
            {
                var entity = dbContext.Set<T>().Find(id);
                if (entity != null)
                {
                    dbContext.Set<T>().Remove(entity);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}