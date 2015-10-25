using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IDropDownListService : IEntityService<DropDownList>
    {
        IEnumerable<DropDownList> GetAllByGroupNameANDIsActive(string groupName, bool IsActive);
    }
}
