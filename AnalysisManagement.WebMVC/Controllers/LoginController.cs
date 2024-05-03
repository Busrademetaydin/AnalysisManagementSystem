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
                ModelState.AddModelError("", "Email or password is incorrect.Please retry.");
                return View(loginVM);
            }

            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError("", "Email not confirmed.");
                return View(loginVM);
            }

            var result = await signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, true);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Drug");
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

            //// Rollerin var olup olmadığını kontrol edin ve yoksa oluşturun
            //    string[] rolesToCreate = { "Analyst", "Admin", "Editor" }; // İstediğiniz rolleri buraya ekleyin

            //    foreach (var roleName in rolesToCreate)
            //    {
            //        if (await roleManager.FindByNameAsync(roleName) == null)
            //        {
            //            await roleManager.CreateAsync(new IdentityRole(roleName));
            //        }
            //    }

            //    // Kullanıcıyı rollerle ilişkilendirin
            //    var result2 = await userManager.AddToRoleAsync(appUser, "Analyst");

            //    if (result2.Succeeded)
            //    {
            //        return RedirectToAction("Index", "Drug");
            //    }

            //    return View(registerVM);
            //}

            //Evet, birden fazla role tanımlayabilirsiniz.
            //AddToRoleAsync yöntemini birden fazla kez çağırarak kullanıcıya
            //birden fazla rol atayabilirsiniz.Örneğin:

            //var result2 = await userManager.AddToRoleAsync(appUser, "Analyst");
            //var result3 = await userManager.AddToRoleAsync(appUser, "Admin");
            //var result4 = await userManager.AddToRoleAsync(appUser, "Editor");

            //if (result2.Succeeded && result3.Succeeded && result4.Succeeded)
            //{
            //    return RedirectToAction("Index", "Drug");
            //}

            //return View(registerVM);

            if (await roleManager.FindByNameAsync("Analyst") == null)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Analyst";
                roleManager.CreateAsync(role);
            }

            var result2 = await userManager.AddToRoleAsync(appUser, "Analyst");

            if (result2.Succeeded)
            {
                return RedirectToAction("Index", "Drug");
            }
            return View(registerVM);


        }

    }
}
