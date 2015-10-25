using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Model
{
    [Table("SOP")]
    public class SOP : AuditableEntity<long>
    {
        [Key]
        public long SOPID { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "SOP Name:")]
        public string SOPName { get; set; }

        [Required(ErrorMessage = "Test ID field is required")]
        [MaxLength(50)]
        [Display(Name = "SOP ID")]
        public string SID { get; set; }

        [Required]
        [MaxLength(2000)]
        [Display(Name = "SOP Description:")]
        public string SOPDescription { get; set; }

        [Required]
        [MaxLength(2000)]
        [Display(Name = "Word Component:")]
        [AllowHtml]
        public string SOPHtml { get; set; }

        [MaxLength(250)]
        [Display(Name = "Attach File:")]
        public string FileName { get; set; }

        [Display(Name = "Define Formula:")]
        public string Formula { get; set; }

        [Display(Name = "Test ID")]
        public long  TestID { get; set; }

        [ForeignKey("TestID")]
        public virtual Test test { get; set; }
    }
}
