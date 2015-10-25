using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web;
using System.ComponentModel.DataAnnotations;
using Model;
namespace Web.ViewModel
{
    public class ProductViewModel
    {
        [Display(Name="Date From")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FromDate { get; set; }

        [Display(Name = "Date To")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ToDate { get; set; }

        [Display(Name = "Product Id")]
        public string PID { get; set; }

        public IEnumerable<Product> lstProducts { get; set; }
    }
}