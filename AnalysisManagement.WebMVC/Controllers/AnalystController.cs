using Microsoft.AspNetCore.Mvc;

namespace AnalysisManagement.WebMVC.Controllers
{
    public class AnalystController : Controller
    {
        public AnalystController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
