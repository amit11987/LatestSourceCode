using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interface
{
    public interface IProductRecievedRepository : IGenericRepository<ProductRecieved>
    {
        ProductRecieved GetById(long productReceivedID);
    }
}
