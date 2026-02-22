using System.ComponentModel;

namespace CncApp_Final.Services
{
    public interface IListService
    {
        IBindingList GetAll();
        void DeleteById(int id);
    }
}