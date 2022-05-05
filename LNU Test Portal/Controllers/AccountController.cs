using Data_Access_Layer.Entities;
using LNU_Test_Portal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Logging;

namespace MyShelter.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ILogger<AccountController> logger;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("GetAllCourses", "Course");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    City = model.City
                };

                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (!roleManager.RoleExistsAsync("Student").Result)
                    {
                        await roleManager.CreateAsync(new IdentityRole("Student"));//create role
                    }
                    if (!roleManager.RoleExistsAsync("Teacher").Result)
                    {
                        await roleManager.CreateAsync(new IdentityRole("Teacher"));//create role
                    }
                    await userManager.AddToRoleAsync(user, "Student");  // add default role
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("GetAllCourses", "Course");
                }


                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null && await userManager.IsEmailConfirmedAsync(user))
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);

                    var passwordResetLink = Url.Action("ResetPassword", "Account",
                            new { email = model.Email, token = token }, Request.Scheme);

                    //ViewData["PwdResetLink"] = passwordResetLink;


                    return View("ForgotPasswordConfirmation");
                }

                return View("ForgotPasswordConfirmation");
            }

            return View(model);
        }


    }
}