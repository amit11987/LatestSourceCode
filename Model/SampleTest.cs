using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model
{

    [Table("SampleTest")]
    public class SampleTest : AuditableEntity<long>
    {
        [Key]
        public long SampleTestID { get; set; }

        public long TestID { get; set; }

        [ForeignKey("TestID")]
        [Display(Name="Test Name")]
        public virtual Test test { get; set; }

        [Required]
        [Display(Name = "Repetition")]
        public Int32 Repetition { get; set; }

        public long SampleReceiveID { get; set; }

        [ForeignKey("SampleReceiveID")]
        public virtual SampleReceive sampleReceive { get; set; }
    }
}
