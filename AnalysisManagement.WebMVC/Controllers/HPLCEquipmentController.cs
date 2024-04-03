using Analysis.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisManagement.WebMVC.Controllers
{
    public class HPLCEquipmentController : Controller
    {
        private readonly IHPLCEquipmentManager manager;

        public HPLCEquipmentController(IHPLCEquipmentManager manager)
        {
            this.manager = manager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await manager.GetAllAsync();

            return View();
        }
    }
}
