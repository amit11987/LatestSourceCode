using Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Model;

namespace Web.ViewModel
{
    public class SOPViewModel
    {
        [Display(Name = "Date From")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FromDate { get; set; }

        [Display(Name = "Date To")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ToDate { get; set; }
        
        [Display(Name = "SOP Id")]
        public string SPID { get; set; }

        public IEnumerable<SOP> lstSOP { get; set; }
    }
}