using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementApp.Models
{
    public class UserDetailsModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }
        public int studentId { get; set; }
        public string userName { get; set; }
        public string courseDetails { get; set; }
        public int? courseId { get; set; }
        public string moduleName { get; set; }
        public string instructorName { get; set; }
        public string totalFees { get; set; }
        public double feesPaid { get; set; }
        public double dueFees { get; set; }
        public int moduleId { get; set; }
        public int? batchId { get; set; }
        public DateTime? dateOfPayment { get; set; }
        public DateTime? dateOfJoining { get; set; }
        public DateTime? dueDate { get; set; }
        public string status { get; set; }
        public string RegistrationId { get; set; }
    }
}