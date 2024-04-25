using Analysis.Business.Abstract;
using Analysis.Entities.Concrete;
using AnalysisManagement.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisManagement.WebMVC.Controllers
{
    public class DrugController : Controller
    {
        private readonly IDrugManager manager;
        //private readonly IMapper mapper;

        public DrugController(IDrugManager manager)
        {
            this.manager = manager;
        }
        public async Task<IActionResult> Index()
        {
            var result = manager.GetAllAsync().Result;
            return View(result);
        }

        public async Task<IActionResult> InsertAsync()
        {
            DrugInsertVM insertVM = new();
            return View(insertVM);
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
                    //ModelState.AddModelError("", ex.Message);

                    //return View();

                }
                return RedirectToAction("Index");
            }

            return View(drug);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var drug = await manager.GetByIdAsync(id);

            if (drug == null)
            {
                return NotFound();
            }
            return View(drug);
        }
        public async Task<IActionResult> DeleteAsync(int drugid)
        {
            var drug = await manager.GetByIdAsync(drugid);

            return View(drug);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete2(int DrugId)
        {
            try
            {
                var drug = await manager.GetByIdAsync(DrugId);
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
