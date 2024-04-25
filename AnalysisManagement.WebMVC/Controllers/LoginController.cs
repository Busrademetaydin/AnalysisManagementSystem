using AnalysisManagement.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisManagement.WebMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            LoginVM loginVM = new LoginVM();
            return View(loginVM);
        }

        //[HttpPost]
        //public async Task<IActionResult> Index(LoginVM loginVM)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(loginVM);
        //    }
        //}

    }
}
