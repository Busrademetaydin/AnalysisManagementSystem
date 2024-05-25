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

        public IActionResult Services()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact([FromBody] ContactVM model)
        {
            if (ModelState.IsValid)
            {
                var contactMessage = new ContactMessage
                {
                    Name = model.Name,
                    Email = model.Email,
                    Subject = model.Subject,
                    Message = model.Message
                };
                dbcontext.ContactMessages.Add(contactMessage);
                await dbcontext.SaveChangesAsync();


                return Ok("Thank you for contacting us!");

            }
            else
            {

                return BadRequest(ModelState);
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