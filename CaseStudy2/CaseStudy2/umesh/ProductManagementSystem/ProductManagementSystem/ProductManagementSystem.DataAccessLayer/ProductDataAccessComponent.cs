using ProductManagementSystem.Entities;
using ProductManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagementSystem.DataAccessLayer
{
    public class ProductDataAccessComponent :
        IProductDataAccessComponent<Product>
    {
        //private List<Product> allProducts;
        //public ProductDataAccessComponent()
        //{
        //    allProducts = ProductRepository.GetProducts();
        //}
        public bool Add(Product newItem)
        {
            try
            {
                List<Product> allProducts = ProductRepository.GetProducts();
                IEnumerable<Product> foundProducts = allProducts.Where(p => p.Id == newItem.Id);

                if (foundProducts != null &&
                    foundProducts.Count() > 0)
                {
                    return false;
                }
                else
                {
                    allProducts.Add(newItem);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Product> FetchAll()
        {
            try
            {
                return ProductRepository.GetProducts();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Remove(int id)
        {
            try
            {
                List<Product> allProducts = ProductRepository.GetProducts();

                IEnumerable<Product> foundProducts = allProducts.Where(p => p.Id == id);

                if (foundProducts != null &&
                    foundProducts.Count() > 0)
                {
                    var foundProduct = foundProducts.First();
                    allProducts.Remove(foundProduct);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Product updatedItem)
        {
            try
            {
                List<Product> allProducts = ProductRepository.GetProducts();

                IEnumerable<Product> foundProducts = allProducts.Where(p => p.Id == updatedItem.Id);

                if (foundProducts != null &&
                    foundProducts.Count() > 0)
                {
                    var foundProduct = foundProducts.First();
                    foundProduct.Name = updatedItem.Name;
                    foundProduct.Price = updatedItem.Price;
                    foundProduct.Description = updatedItem.Description;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
