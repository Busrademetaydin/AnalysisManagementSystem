using Analysis.Business.Abstract;
using Analysis.Entities.Concrete;
using AnalysisManagement.WebMVC.Models;
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

            return View(result);
        }

        public async Task<IActionResult> InsertAsync()
        {
            HPLCEquipmentInsertVM insertVM = new();
            return View(insertVM);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(HPLCEquipmentInsertVM equipment)
        {
            if (ModelState.IsValid)
            {
                HPLCEquipment equipment1 = new HPLCEquipment()
                {
                    Brand = equipment.Brand,
                    SerialNumber = equipment.SerialNumber,
                    CalibrationDueDate = equipment.CalibrationDueDate

                };

                try
                {
                    var result = await manager.InsertAsync(equipment1);
                }
                catch (Exception ex)
                {
                    //ModelState.AddModelError("", ex.Message);

                    //return View();

                }
                return RedirectToAction("Index");
            }

            return View(equipment);
        }

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
