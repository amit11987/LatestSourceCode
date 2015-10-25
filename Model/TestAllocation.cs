using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model
{
    public class TestAllocation : AuditableEntity<long>
    {
        [Key]
        public long TestAllocationID { get; set; }

        [Display(Name = "Target Date")]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime TargetDate { get; set; }

        [Required]
        [Display(Name = "Sample ID")]
        public long SampleReceiveID { get; set; }

        [ForeignKey("SampleReceiveID")]
        public virtual SampleReceive sampleReceive { get; set; }
       
        public string SRID { get; set; }

        [Display(Name = "Test Name")]
        public long TestID { get; set; }

        [ForeignKey("TestID")]
        public virtual Test test { get; set; }

        [NotMapped]
        [Display(Name = "Test Name")]
        public string TestName { get; set; }
        
        [Required]
        public string Status { get; set; }

        
        public virtual List<UserGroup> lstUserGroup { get; set; }

         [Required]
        [Display(Name = "Qty Of Product")]
        public string QtyOfProduct { get; set; }

        [Required]
        [Display(Name = "UOM")]
        public long UOMID { get; set; }

        [ForeignKey("UOMID")]
        public virtual UOM uom { get; set; }

        public virtual List<TestAllocationUserGroup> testAllocationUserGroup { get; set; }
    }
}
