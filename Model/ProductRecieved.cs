using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model
{
    [Table("ProductRecieved")]
    public class ProductRecieved : AuditableEntity<long>
    {
        [Key]
        public long ProductRecievedID { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public decimal Quantity { get; set; }

        [Required]
        [Display(Name = "UOM")]
        public long UOMID { get; set; }

        [ForeignKey("UOMID")]
        public virtual UOM uom { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public long ProductID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product product { get; set; }

        public long SampleReceiveID { get; set; }

        [ForeignKey("SampleReceiveID")]
        public virtual SampleReceive sampleReceive { get; set; }
    }
}
