using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model
{
     [Table("UserGroupAssign")]
    public class UserGroupAssign : AuditableEntity<long>
    {
        [Key]
        public long UserGroupAssignID { get; set; }

        public long UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User user { get; set; }

        public long UserGroupID { get; set; }
        
        [ForeignKey("UserGroupID")]
        public virtual UserGroup userGroup { get; set; }
    }
}
