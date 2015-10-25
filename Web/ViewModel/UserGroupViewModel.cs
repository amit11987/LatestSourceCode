using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ViewModel
{
    public class UserGroupViewModel
    {
        public UserGroup userGroup { get; set; }
        public List<User> lstUsers { get; set; }
        public List<UserGroup> lstUserGroups { get; set; }
    }
}