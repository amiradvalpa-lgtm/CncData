using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CncApp_Final.Entities;
using CncApp_Final.Services;

namespace CncApp_Final.Services
{
    public class DummyCrudService : ICrudService<Customer>
    {
        public void Add(Customer entity)
        {
            // کاری انجام نمی‌دهد
        }

        public void Delete(Customer entity)
        {
            // کاری انجام نمی‌دهد
        }

        public Customer GetById(int id)
        {
            // یک Customer خالی برمی‌گرداند
            return new Customer();
        }

        public void SaveChanges()
        {
            // کاری انجام نمی‌دهد
        }

        public void Reload(Customer entity)
        {
            // کاری انجام نمی‌دهد
        }

        public bool HasChanges() => false;

        public void Update(Customer entity)
        {
            // کاری انجام نمی‌دهد
        }
    }

}
