using Hospital.DAL.Models;
using Hospital.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.PL.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var User = await _userManager.FindByNameAsync(model.UserName);
                if (User is null)
                {
                    User = new ApplicationUser()
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        IsAgree = model.IsAgree,
                    };
                    var result = await _userManager.CreateAsync(User, model.Password);

                    if (result.Succeeded)
                        return RedirectToAction(nameof(SignIn));

                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                }
                ModelState.AddModelError(string.Empty, "UserName is Already Exists");

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> SignIn(SignInViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(model.Email);
				if (user is not null)
				{
					var flag = await _userManager.CheckPasswordAsync(user, model.Password);
					if (flag == true)
					{
						var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
						if (result.Succeeded)
							return RedirectToAction("Index","Home");
					}
				}
				ModelState.AddModelError(string.Empty, "Invalid SignIn");
			}
			return View(model);
		}
        public async new Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(SignIn));

        }
    }
}
