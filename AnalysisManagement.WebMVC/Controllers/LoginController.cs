using Analysis.Entities.Concrete;
using AnalysisManagement.WebMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AnalysisManagement.WebMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

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
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }
            var user = await userManager.FindByEmailAsync(loginVM.Email);
            if (user == null || !await userManager.CheckPasswordAsync(user, loginVM.Password))
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
            var reult2 = await userManager.AddToRoleAsync(user, "admin");
            if (result.Succeeded)
            {
                var roles = await userManager.GetRolesAsync(user);
                if (roles.Contains("Admin"))
                {
                    //return RedirectToAction("Index", "Home", new { area = "Admin" });
                    return RedirectToAction("Index", "Drug");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Login failed. Please try again.");
            return View(loginVM);
        }
        public IActionResult Register()
        {
            RegisterVM registerVM = new();
            return View(registerVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
            else
            {
                await signInManager.SignInAsync(appUser, isPersistent: false);
                return RedirectToAction("Index", "Login");
            }
            var code = await userManager.GenerateEmailConfirmationTokenAsync(appUser);
            StringBuilder message = new();

            message.AppendLine("<html>");
            message.AppendLine("<head>")
                .AppendLine("<meta charset='UTF-8'")
                .AppendLine("</head>"); message.AppendLine($"<p> Hello {appUser.UserName} </p> <br>");

            message.AppendLine("<p> Click the link below to complete the membership process. </p>");

            message.AppendLine($"<a href='http://localhost:7006/ConfirmEmail?uid={appUser.Id}&code={code}'> Confirm </a>");


            message.AppendLine("</body>");


            message.AppendLine("</html>");

            EmailHelper emailHelper = new EmailHelper();
            bool sonuc = await emailHelper.SendEmail(appUser.Email, message.ToString());

            if (sonuc)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "An error occurred while sending an e-mail.");
                return View(registerVM);
            }
        }

        [Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string uid, string code)
        {
            ConfirmEmailModel model = new();

            if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(code))
            {
                var appUser = await userManager.FindByIdAsync(uid);
                code = code.Replace(' ', '+');
                model.Email = appUser.Email;
                var result = await userManager.ConfirmEmailAsync(appUser, code);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var error = result.Errors.FirstOrDefault();
                    model.ErrorDescription = error.Description;
                    model.HasError = true;
                    ModelState.AddModelError("", error.Description);
                    return View(model);
                }
            }
            return View();
        }

    }
}
