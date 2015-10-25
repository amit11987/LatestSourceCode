using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Repository
{
    public class FieldTypeRepository : GenericRepository<FieldType>, IFieldTypeRepository
    {
        public FieldTypeRepository(DbContext context)
            : base(context)
        {

        }

        public IEnumerable<FieldType> GetAllByIsActive(bool IsActive)
        {
            return _dbset.Where(x => x.IsActive == IsActive).AsEnumerable();
        }
    }
}
