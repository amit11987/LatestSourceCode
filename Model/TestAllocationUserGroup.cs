using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model
{
    [Table("TestAllocationUserGroup")]
    public class TestAllocationUserGroup : AuditableEntity<long>
    {
        [Key]
        public long TestAllocationUserGroupID { get; set; }

        public long TestAllocationID { get; set; }

        [ForeignKey("TestAllocationID")]
        public virtual TestAllocation testAllocation { get; set; }

        public long UserGroupID { get; set; }

        [ForeignKey("UserGroupID")]
        public virtual UserGroup userGroup { get; set; }
    }
}
