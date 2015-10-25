﻿using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public interface IUserGroupRepository : IGenericRepository<UserGroup>
    {

        UserGroup GetById(long id);
    }
}
