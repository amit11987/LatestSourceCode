using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Repository
{
    public class DropDownListRepository : GenericRepository<DropDownList>, IDropdownListRepository
    {
        public DropDownListRepository(DbContext context)
            : base(context)
        {

        }

        public IEnumerable<DropDownList> GetAllByGroupNameANDIsActive(string groupName, bool IsActive)
        {
            return _dbset.Where(x => x.IsActive == IsActive && x.GroupName == groupName).AsEnumerable();
        }
    }
}
