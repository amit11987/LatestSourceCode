using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interface
{
    public interface IDropdownListRepository : IGenericRepository<DropDownList>
    {
        IEnumerable<DropDownList> GetAllByGroupNameANDIsActive(string groupName,  bool IsActive);
    }
}
