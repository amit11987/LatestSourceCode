using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public interface IFieldTypeRepository : IGenericRepository<FieldType>
    {
        IEnumerable<FieldType> GetAllByIsActive(bool IsActive);
    }
}
