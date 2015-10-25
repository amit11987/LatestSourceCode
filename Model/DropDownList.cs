using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model
{
    [Table("DropDownList")]
    public class DropDownList : BaseEntity
    {
        [Key]
        public long DropDownListID { get; set; }

        public string ItemName { get; set; }

        public string ItemValue { get; set; }

        public string GroupName { get; set; }

        public bool IsActive { get; set; }
    }
}
