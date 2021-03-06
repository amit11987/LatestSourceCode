﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public interface IUserService : IEntityService<User>
    {
        User GetById(long Id);
        IEnumerable<User> GetByISActive(bool IsActive);
    }
}
