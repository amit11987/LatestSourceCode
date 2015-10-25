using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public interface IUOMRepository : IGenericRepository<UOM>
    {
        UOM GetById(long UOMID);

        IEnumerable<UOM> GetAllByIsStandardUOM(bool ISStandardUOM);
    }
}
