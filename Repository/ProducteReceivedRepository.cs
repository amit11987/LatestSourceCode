using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Repository
{
    public class ProducteReceivedRepository : GenericRepository<ProductRecieved>, IProductRecievedRepository
    {
        public ProducteReceivedRepository(DbContext context)
            : base(context)
        {

        }

        public ProductRecieved GetById(long productReceivedID)
        {
            return _dbset.Where(x => x.ProductRecievedID == productReceivedID).FirstOrDefault();
        }
    }
}
