using ProductManagementSystem.DataAccessLayer;
using ProductManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementSystem.BusinessLayer
{
    public class ProductBusinessComponent : IProductBusinessComponent<Product>
    {
        private ProductDataAccessComponent dataAccessComponent;

        public bool Delete(int id)
        {
            try
            {
                dataAccessComponent = new ProductDataAccessComponent();
                return dataAccessComponent.Remove(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Product> GetAll()
        {
            try
            {
                dataAccessComponent = new ProductDataAccessComponent();
                return dataAccessComponent.FetchAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(Product newItem)
        {
            try
            {
                dataAccessComponent = new ProductDataAccessComponent();
                return dataAccessComponent.Add(newItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Modify(Product updatedItem)
        {
            try
            {
                dataAccessComponent = new ProductDataAccessComponent();
                return dataAccessComponent.Update(updatedItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
