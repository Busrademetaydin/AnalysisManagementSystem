using Analysis.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisManagement.WebMVC.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> AssignRole(string userId, string roleName)
        {

            var user = await _userManager.FindByIdAsync(userId);

            var role = await _roleManager.FindByNameAsync(roleName);

            if (user != null && role != null)
            {

                await _userManager.AddToRoleAsync(user, roleName);
                return RedirectToAction("Index", "Home");
            }

            return NotFound();
        }

        public async Task<IActionResult> RemoveRole(string userId, string roleName)
        {

            var user = await _userManager.FindByIdAsync(userId);


            var role = await _roleManager.FindByNameAsync(roleName);

            if (user != null && role != null)
            {

                await _userManager.RemoveFromRoleAsync(user, roleName);
                return RedirectToAction("Index", "Home");
            }

            return NotFound();
        }
        public async Task<IActionResult> UserRoles(string userId)
        {

            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {

                var roles = await _userManager.GetRolesAsync(user);
                return View(roles);
            }

            return NotFound();
        }


    }
}
