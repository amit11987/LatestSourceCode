using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model
{
    [Table("UOM")]
    public class UOM : AuditableEntity<long>
    {
        [Key]
        public long UOMID { get; set; }

        [MaxLength(250)]
        [Required]
        [Display(Name = "UOM Name:")]
        public string UOMName { get; set; }

        [MaxLength(250)]
        [Display(Name = "Standard UOM:")]
        public string StandardUOM { get; set; }

        [Display(Name = "IS Standard UOM:")]
        public bool ISStandardUOM { get; set; }

        [Display(Name = "1 [UOM Name]*")]
        public Decimal UOMMapping { get; set; }

    }
}
