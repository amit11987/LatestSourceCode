using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model
{

    [Table("Test")]
    public class Test : AuditableEntity<long>
    {
        [Key]
        public long TestID { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Test Name:")]
        public string TestName { get; set; }

        [Required]
        [MaxLength(2000)]
        [Display(Name = "Test Description:")]
        public string TestDescription { get; set; }

        [Required]
        [Display(Name = "Number of parameters required:")]
        public int NumberOfParametersRequired { get; set; }

        [Required(ErrorMessage = "Test ID field is required")]
        [MaxLength(50)]
        [Display(Name = "Test ID")]
        public string TID { get; set; }

        public virtual List<TestParameter> TestParameters { get; set; }
    }
}
