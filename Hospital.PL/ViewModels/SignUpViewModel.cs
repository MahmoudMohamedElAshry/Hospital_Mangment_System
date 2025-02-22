using System.ComponentModel.DataAnnotations;

namespace Hospital.PL.ViewModels
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "User Name Is Required")]

        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is Recuired")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Recuired")]
        [MinLength(8, ErrorMessage = "Minimum Password Lingth is 8")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is Recuired")]
        [MinLength(8, ErrorMessage = "Minimum Confirm Password Lingth is 8")]
        [Compare(nameof(Password), ErrorMessage = "Confirm Password Does Not Match Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
		[Required(ErrorMessage = "IsAgree is Recuired")]

		public bool IsAgree { get; set; }
    }
}
