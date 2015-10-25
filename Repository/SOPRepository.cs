using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Repository
{
    public class SOPRepository : GenericRepository<SOP>, ISOPRepository
    {
        public SOPRepository(DbContext context)
            : base(context)
        {

        }

        public SOP GetById(long sopID)
        {
            return _dbset.Where(x => x.SOPID == sopID).FirstOrDefault();
        }
    }
}
