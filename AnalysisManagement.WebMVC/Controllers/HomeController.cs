using Analysis.Data.AppDbContext;
using Analysis.Entities.Concrete;
using AnalysisManagement.WebMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AnalysisManagement.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AnalysisDbContext dbcontext;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public HomeController(ILogger<HomeController> logger, AnalysisDbContext dbcontext, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _logger = logger;
            this.dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            //var result = dbcontext.Role.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactVM model)
        {
            if (ModelState.IsValid)
            {
                // Form verilerini kullanarak veritabanına kayıt işlemleri
                // Örneğin: _context.ContactMessages.Add(new ContactMessage { ... });
                // Bu işlemleri gerçekleştirdikten sonra başka bir sayfaya yönlendirme yapabilirsiniz.
                return RedirectToAction("Index", "Home"); // Örnek bir yönlendirme

            }
            else
            {
                // Model geçerliliği sağlanmadıysa, hata mesajlarını göstermek için Contact sayfasına geri dönün
                return View(model);
            }
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
