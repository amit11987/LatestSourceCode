using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public interface IUserGroupService : IEntityService<UserGroup>
    {
        UserGroup GetById(long Id);

        IEnumerable<UserGroup> GetByISActive(bool ISActive);
    }
}
