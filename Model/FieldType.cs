using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model
{
    [Table("FieldType")]
    public class FieldType : BaseEntity
    {
        [Key]
        public long FieldTypeID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "FieldType")]
        public string FieldTypeName { get; set; }

        public bool IsActive { get; set; }
    }
}
