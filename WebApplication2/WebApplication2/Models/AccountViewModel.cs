using System.ComponentModel.DataAnnotations;


namespace WebApplication2.Models
{

        public class ExternalLoginViewModel
        {
            public string Action { get; set; }
            public string ReturnUrl { get; set; }
        }
 
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class EditMemberViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Skills")]
        public string Skills { get; set; }

        [Required]
        [Display(Name = "Educational Degree")]
        public string EduDegree { get; set; }

        [Required]
        [Display(Name = "School")]
        public string EduSchool { get; set; }

        [Required]
        [Display(Name = "Last Job Postion")]
        public string XpPosition { get; set; }

        [Required]
        [Display(Name = "From Company ")]
        public string XpCompany { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Expected Salary")]
        public string ExpSalary { get; set; }

    }

    public class ProfileMemberViewModel
    {
        
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Skills")]
        public string Skills { get; set; }

        [Display(Name = "Educational Degree")]
        public string EduDegree { get; set; }

        
        [Display(Name = "School")]
        public string EduSchool { get; set; }
        
        [Display(Name = "Last Job Postion")]
        public string XpPosition { get; set; }
        
        [Display(Name = "From Company ")]
        public string XpCompany { get; set; }
        
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Expected Salary")]
        public string ExpSalary { get; set; }

    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Employer ?")]
        public bool Role { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}