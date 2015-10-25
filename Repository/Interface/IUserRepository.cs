using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {

        User GetById(long id);
    }
}
