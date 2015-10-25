using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context)
            : base(context)
        {

        }

        public Product GetById(long productID)
        {
            return _dbset.Where(x => x.ProductID == productID).FirstOrDefault();
        }
    }
}
