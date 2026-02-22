// مسیر: Services/EfListService.cs
using CncApp_Final.Data;
using System.ComponentModel;
using System.Data.Entity;

namespace CncApp_Final.Services
{
    public class EfListService<T> : IListService where T : class
    {
        protected readonly AppDbContext DbContext;
        protected readonly DbSet<T> DbSet;

        public EfListService(AppDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }

        public virtual IBindingList GetAll()
        {
            DbSet.Load();
            return DbSet.Local.ToBindingList();
        }

        public void DeleteById(int id)
        {
            var entity = DbSet.Find(id);
            if (entity != null)
            {
                DbSet.Remove(entity);
                DbContext.SaveChanges();
            }
        }
    }
}