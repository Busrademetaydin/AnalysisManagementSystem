using Analysis.Business.Abstract;
using Analysis.Entities.Concrete;
using AnalysisManagement.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisManagement.WebMVC.Controllers
{
    public class AnalysisController : Controller
    {
        private readonly IAnalysisManager manager;

        public AnalysisController(IAnalysisManager manager)

        {
            this.manager = manager;
        }

        public IActionResult Index()
        {
            var result = manager.GetAllAsync().Result;
            return View(result);
        }

        public async Task<IActionResult> InsertAsync()
        {
            AnalyzeInsertVM insertVM = new();
            return View(insertVM);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(AnalyzeInsertVM analyze)
        {
            if (ModelState.IsValid)
            {
                Analyze analysis = new Analyze()
                {
                    //Id = analyze.AnalyzeId,

                    AnalyzeTypeId = analyze.AnalyzeTypeId,
                    AnalystId = analyze.AnalystId,
                    EquipmentId = analyze.EquipmentId


                };

                try
                {
                    await manager.InsertAsync(analysis);
                }
                catch (Exception ex)
                {


                }
                return RedirectToAction("Index");
            }

            return View(analyze);
        }

    }
}