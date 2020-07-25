using Hippo.SuperMarket.Domain.Abstract;
using Hippo.SuperMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hippo.SuperMarket.Domain.Concrete
{
    public class InMemoryProductsRepository : IProductsRepository
    {
        private List<Product> _products = new List<Product>
        {
            new Product { Name="Pork", Price=3},
            new Product { Name="Beef", Price=5},
            new Product { Name="Lamb", Price=6},
            new Product { Name="Chicken", Price=4},
            new Product { Name="Salmon", Price=7},
        };

        public IEnumerable<Product> Products
        {
            get
            {
                return _products;
            }
        }
    }
}
