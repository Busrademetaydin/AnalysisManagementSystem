using Analysis.Business.Abstract;
using Analysis.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisManagement.WebMVC.Controllers
{
    public class DrugController : Controller
    {
        private readonly IDrugManager manager;

        public DrugController(IDrugManager manager)
        {
            this.manager = manager;
        }
        public IActionResult Index()
        {
            var result = manager.GetAll().Result;
            return View(result);
        }

        public async Task<IActionResult> Insert()
        {
            Drug drug = new Drug();
            return View(drug);
        }

    }
}
