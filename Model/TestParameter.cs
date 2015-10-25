using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model
{
    [Table("TestParameter")]
    public class TestParameter : AuditableEntity<long>
    {
        [Key]
        public long TestParameterID { get; set; }
        
        [Required]
        [MaxLength(100)]
        [Display(Name="Caption")]
        public string Caption { get; set; }

        [Required]
        [MaxLength(2000)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Test Parameterield is required")]
        [MaxLength(50)]
        [Display(Name = "ID")]
        public string TPID { get; set; }      

        public long TestID { get; set; }

        [ForeignKey("TestID")]
        public virtual Test test { get; set; }

        [Required]
        [Display(Name = "FieldType")]
        public long FieldTypeID { get; set; }

        [ForeignKey("FieldTypeID")]
        public virtual FieldType FieldType { get; set; }
    }
}
