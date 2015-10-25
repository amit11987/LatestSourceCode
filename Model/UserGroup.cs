using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model
{
    [Table("UserGroup")]
    public class UserGroup : AuditableEntity<long>
    {
        [Key]
        public long UserGroupID { get; set; }

        [Display(Name = "User Group Name")]
        public string UserGroupName { get; set; }

        [Display(Name = "User Group Description")]
        public string UserGroupDescription { get; set; }

        public virtual List<UserGroupAssign> lstUserGroupAssign { get; set; }
    }
}
