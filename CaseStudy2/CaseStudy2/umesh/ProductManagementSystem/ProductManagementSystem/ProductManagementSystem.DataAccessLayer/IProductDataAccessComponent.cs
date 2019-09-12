using System.Collections.Generic;

namespace ProductManagementSystem.DataAccessLayer
{
    public interface IProductDataAccessComponent<T> where T : class, new()
    {
        List<T> FetchAll();
        bool Add(T newItem);
        bool Remove(int id);
        bool Update(T updatedItem);
    }
}
