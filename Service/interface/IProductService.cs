using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public interface IProductService : IEntityService<Product>
    {
        Product GetById(long Id);
    }
}
