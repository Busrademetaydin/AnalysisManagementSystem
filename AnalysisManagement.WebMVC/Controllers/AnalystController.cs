using Analysis.Data.AppDbContext;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisManagement.WebMVC.Controllers
{
    public class AnalystController : Controller
    {
        private AnalysisDbContext db = new AnalysisDbContext();

        public ActionResult GetAnalysts(string term)
        {
            var analysts = db.Analysts
                .Where(a => a.FirstName.Contains(term))
                .Select(a => new { id = a.Id, label = a.FirstName })
                .ToList();

            return Json(analysts);

        }

        public AnalystController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }

}

