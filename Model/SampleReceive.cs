using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model
{
    [Table("SampleReceive")]
    public class SampleReceive : AuditableEntity<long>
    {
        [Key]
        public long SampleReceiveID { get; set; }
        
        [Required]
        [MaxLength(250)]
        [Display(Name = "Sample ID:")]
        public string SRID { get; set; }

        [Display(Name = "No Of Product Received:")]
        public int NoOfProductReceived { get; set; }

        [Display(Name = "No Of Test Required:")]
        public int NoOfTestRequired { get; set; }


        [Display(Name = "Target Date:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime TargetDate { get; set; }

        public virtual List<ProductRecieved> lstProductRecieved { get; set; }

        public virtual List<SampleTest> lstSampleTest { get; set; }
    }
}
