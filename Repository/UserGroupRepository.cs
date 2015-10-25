using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Repository
{
    public class UserGroupRepository : GenericRepository<UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(DbContext context)
            : base(context)
        {

        }

        public UserGroup GetById(long UserGroupID)
        {
            return _dbset.Where(x => x.UserGroupID == UserGroupID).FirstOrDefault();
        }
    }
}
