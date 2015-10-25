using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Model
{
    [Table("Users")]
    public class User : AuditableEntity<long>
    {
        [Key]
        public long UserID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Employee ID")]

        public string EmployeeID { get; set; }

        [Required]
        [Display(Name = "Login ID")]
        public string LoginID { get; set; }


        [Display(Name = "Use Employee ID As LoginID")]
        public bool UseEmployeeIDAsLoginID { get; set; }

        [Required]
        [Display(Name = "Email ID")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }

        [Required]
        [Display(Name = "Phone No")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string PhoneNo { get; set; }

        [Required]
        [Display(Name = "Emergency ContactNo")]
        public string EmergencyContactNo { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Minimum length should be 6")]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        [Display(Name = "Compare Password")]
        public string ConfirmPassword { get; set; }
    }
}
