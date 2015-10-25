using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public interface IUOMService : IEntityService<UOM>
    {
        UOM GetById(long UOMID);

        IEnumerable<UOM> GetAllByIsStandardUOM(bool ISStandardUOM);
    }
}
