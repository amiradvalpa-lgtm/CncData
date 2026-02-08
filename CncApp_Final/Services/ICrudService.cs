using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CncApp_Final.Services
{
    public interface ICrudService<T> where T : class
    {
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool HasChanges();
        void SaveChanges();
        void Reload(T entity);
    }
}
