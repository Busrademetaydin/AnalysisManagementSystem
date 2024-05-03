using Analysis.Business.Abstract;
using Analysis.Entities.Concrete;
using AnalysisManagement.WebMVC.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisManagement.WebMVC.Controllers
{
    [Authorize(Roles = "Analyst")]
    public class DrugController : Controller
    {
        private readonly IDrugManager manager;
        private readonly INotyfService notyf;
        private readonly IMapper mapper;

        public DrugController(IDrugManager manager, INotyfService notyf, IMapper mapper)
        {
            this.manager = manager;
            this.notyf = notyf;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var result = manager.GetAllAsync().Result;
            return View(result);
        }
        public ActionResult Details(int id)
        {
            return View();
        }

        //[Authorize(Roles = "Supervisor")]
        public async Task<IActionResult> InsertAsync()
        {
            DrugInsertVM drug = new();
            return View(drug);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(DrugInsertVM drug)
        {
            if (ModelState.IsValid)
            {
                Drug drug1 = new()
                {

                    ProductCode = drug.ProductCode,
                    BatchNo = drug.BatchNo,
                    DosageForm = drug.DosageForm,
                    Description = drug.Description,
                    MFGDate = drug.MFGDate,
                    EXPDate = drug.EXPDate,
                    StorageCondition = drug.StorageCondition
                };

                try
                {
                    var result = await manager.InsertAsync(drug1);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    notyf.Error("Hata:" + ex.Message);
                    return View();
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
        public async Task<IActionResult> Edit(int id)
        {
            var result = await manager.GetByIdAsync(id);
            var update = mapper.Map<DrugUpdateVM>(result);


            return View(update);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DrugUpdateVM updateVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var drug = mapper.Map<Drug>(updateVM);
                    manager.UpdateAsync(drug);
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
            var drug = await manager.GetByIdAsync(Id);

            return View(drug);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int Id)
        {
            try
            {
                var drug = await manager.GetByIdAsync(Id);
                await manager.DeleteAsync(drug);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }
    }
}
