using Analysis.Business.Abstract;
using Analysis.Entities.Concrete;
using AnalysisManagement.WebMVC.Models.Entity;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisManagement.WebMVC.Controllers
{

    [Authorize(Roles = "Admin")]
    public class HPLCEquipmentController : Controller
    {
        private readonly IHPLCEquipmentManager manager;
        private readonly INotyfService notyf;
        private readonly IMapper mapper;

        public HPLCEquipmentController(IHPLCEquipmentManager manager, INotyfService notyf, IMapper mapper)
        {
            this.manager = manager;
            this.notyf = notyf;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var result = await manager.GetAllAsync();

            return View(result);
        }

        public async Task<IActionResult> InsertAsync()
        {
            HPLCEquipmentInsertVM equipment = new();
            return View(equipment);
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
                    ModelState.AddModelError("", ex.Message);
                    notyf.Error("Hata:" + ex.Message);
                    return View();

                }
                return RedirectToAction("Index");
            }

            return View(equipment);
        }


        public ActionResult Details(int id)
        {
            var equip = manager.GetByIdAsync(id).Result;

            if (equip == null)
            {
                return NotFound();
            }


            return View(equip);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await manager.GetByIdAsync(id);
            var update = mapper.Map<HPLCEquipmentUpdateVM>(result);


            return View(update);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(HPLCEquipmentUpdateVM updateVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var equipment = mapper.Map<HPLCEquipment>(updateVM);
                    manager.UpdateAsync(equipment);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var equipment = await manager.GetByIdAsync(Id);

            return View(equipment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int Id)
        {
            try
            {
                var equipment = await manager.GetByIdAsync(Id);
                await manager.DeleteAsync(equipment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }
    }
}
