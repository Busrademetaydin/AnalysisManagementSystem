using Analysis.Data.AppDbContext;
using AnalysisManagement.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AnalysisManagement.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AnalysisDbContext dbcontext;

        public HomeController(ILogger<HomeController> logger, AnalysisDbContext dbcontext)
        {
            _logger = logger;
            this.dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            var result = dbcontext.Role.ToList();
            return View();
        }

        public IActionResult Privacy()
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
