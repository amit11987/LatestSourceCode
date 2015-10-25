using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Repository
{
    public class UOMRepository : GenericRepository<UOM>, IUOMRepository
    {
        public UOMRepository(DbContext context)
            : base(context)
        {

        }

        public UOM GetById(long UOMID)
        {
            return _dbset.Where(x => x.UOMID == UOMID).FirstOrDefault(); 
        }

        public IEnumerable<UOM> GetAllByIsStandardUOM(bool ISStandardUOM)
        {
            return _dbset.Where(x => x.ISStandardUOM == ISStandardUOM).ToList(); 
        }
    }
}
