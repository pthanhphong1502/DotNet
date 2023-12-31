using JZsGreen.Data;
using JZsGreen.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JZsGreen.Controllers
{
    public class UserAuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JZenoDbContext _context;

        public UserAuthController(JZenoDbContext context,
                                  UserManager<User> userManager,
                                  SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            loginModel.LoginInValid = "true";

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.UserName!,
                                                                     loginModel.Pass!,
                                                                     loginModel.RememberMe,
                                                                     lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    loginModel.LoginInValid = "";
                }
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "Tài Khoản của bạn đã bị khóa");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Vui lòng kiểm tra tài khoản hoặc mật khẩu");
                }

            }
            return PartialView("_UserLoginPartial", loginModel);

        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }


          [AllowAnonymous]
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> RegisterUser(RegistrationModel registrationModel)
         {

             if (ModelState.IsValid)
             {
                User user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = registrationModel.Email,
                    Email = registrationModel.Email,
                    NormalizedEmail = registrationModel.Email!.ToUpper(),
                    PhoneNumber = registrationModel.PhoneNumber,
                    fullName = registrationModel.FullName,
                    dateCreated = DateTime.Now,
                    LockoutEnabled = false,
                    point = 0
                 };

                 var result = await _userManager.CreateAsync(user, registrationModel.Password!);

                if (result.Succeeded)
                {
                    registrationModel.RegistrationInValid = "";

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _userManager.AddToRoleAsync(user, "Customer").Wait();

                    return PartialView("_UserRegistrationPartial", registrationModel);
                }

                AddErrorsToModelState(result);

            }
            return PartialView("_UserRegistrationPartial", registrationModel);

        }

        [AllowAnonymous]
         public async Task<bool> UserNameExists(string userName)
         {
             bool userNameExists = await _context.Users.AnyAsync(u => u.UserName!.ToUpper() == userName.ToUpper());

             if (userNameExists)
                 return true;

             return false;

         }

         private void AddErrorsToModelState(IdentityResult result)
         {
             foreach (var error in result.Errors)
                 ModelState.AddModelError(string.Empty, error.Description);
         }    
    }
}
