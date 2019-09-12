using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProductManagementSystem.Entities;

namespace ProductManagementSystem.Repository
{
    public static class ProductRepository
    {
        private static List<Product> products;
        static ProductRepository()
        {
            products = new List<Product>
            {
                new Product{ Id = 1, Name="dell xps", Price=67000, Description = "new laptop from dell" },
                new Product{ Id = 2, Name="hp probook", Price=56000, Description = "new laptop from hp" },
                new Product{ Id = 3, Name="lenovo laptop", Price=78000, Description = "new laptop from lenovo" }
            };
        }
        public static List<Product> GetProducts()
        {
            return products;
        }
    }
}
