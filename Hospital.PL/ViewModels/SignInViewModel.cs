using System.ComponentModel.DataAnnotations;

namespace Hospital.PL.ViewModels
{
	public class SignInViewModel
	{

		[Required(ErrorMessage = "Email is Recuired")]
		[EmailAddress(ErrorMessage = "Invalid Email")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Password is Recuired")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public bool RememberMe { get; set; }
	}
}
