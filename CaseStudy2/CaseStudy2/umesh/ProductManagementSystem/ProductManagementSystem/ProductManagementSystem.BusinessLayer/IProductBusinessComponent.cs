using System.Collections.Generic;

namespace ProductManagementSystem.BusinessLayer
{
    public interface IProductBusinessComponent<T>
    {
        List<T> GetAll();
        bool Insert(T newItem);
        bool Delete(int id);
        bool Modify(T updatedItem);
    }
}
