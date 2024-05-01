using Analysis.Entities.Concrete;
using AnalysisManagement.WebMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisManagement.WebMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager;

        public LoginController(UserManager<AppUser> userManager,
                                SignInManager<AppUser> signInManager,
                                RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            LoginVM loginVM = new LoginVM();
            return View(loginVM);
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }
            var user = await userManager.FindByEmailAsync(loginVM.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email yada şifre yanliş");
                return View(loginVM);
            }

            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError("", "Email Onaylanmamistir");
                return View(loginVM);
            }

            var result = await signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Drugs");
            }


            return View(loginVM);
        }
        public IActionResult Register()
        {
            RegisterVM registerVM = new RegisterVM();
            return View(registerVM);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            AppUser appUser = new AppUser()
            {
                Email = registerVM.Email,
                TcNo = registerVM.IdentificationNumber,
                UserName = registerVM.UserName

            };

            var result = await userManager.CreateAsync(appUser, registerVM.Password);

            if (!result.Succeeded)
            {
                var error = result.Errors.FirstOrDefault();
                ModelState.AddModelError("", error.Description);
                return View(registerVM);
            }

            if (await roleManager.FindByNameAsync("Analyst") == null)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Analyst";
                roleManager.CreateAsync(role);
            }

            var result2 = await userManager.AddToRoleAsync(appUser, "Analyst");

            if (result2.Succeeded)
            {
                return RedirectToAction("Index", "Drugs");
            }
            return View(registerVM);


        }

    }
}
