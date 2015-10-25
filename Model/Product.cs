using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model
{
    [Table("Product")]
    public class Product : AuditableEntity<long>
    {
        [Key]
        public long ProductID { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name="Product Name")]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(2000)]
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }


        [Required(ErrorMessage = "Product ID field is required")]
        [MaxLength(50)]
        [Display(Name = "Product ID")]
        public string PID { get;set; }

    }
}
