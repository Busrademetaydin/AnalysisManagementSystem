using Analysis.Business.Abstract;
using Analysis.Entities.Concrete;
using AnalysisManagement.WebMVC.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisManagement.WebMVC.Controllers
{
    public class AnalyzeController : Controller
    {
        private readonly IAnalysisManager manager;
        private readonly INotyfService notyf;
        private readonly IMapper mapper;

        public AnalyzeController(IAnalysisManager manager, INotyfService notyf, IMapper mapper)

        {
            this.manager = manager;
            this.notyf = notyf;
            this.mapper = mapper;



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
            var analyze = manager.GetByIdAsync(id).Result;

            if (analyze == null)
            {
                return NotFound();
            }


            return View(analyze);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(AnalyzeInsertVM analyze)
        {
            if (ModelState.IsValid)
            {
                Analyze analysis = new Analyze()
                {


                    AnalyzeTypeId = analyze.AnalyzeTypeId,
                    AnalystId = analyze.AnalystId,
                    EquipmentId = analyze.EquipmentId,
                    StartDate = analyze.StartDate,
                    EndDate = analyze.EndDate,
                    Description = analyze.Description,


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

        public async Task<IActionResult> Edit(int id)
        {
            var result = await manager.GetByIdAsync(id);
            var update = mapper.Map<AnalyzeUpdateVM>(result);


            return View(update);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AnalyzeUpdateVM updateVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var analyze = mapper.Map<Analyze>(updateVM);
                    manager.UpdateAsync(analyze);
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
            var analyze = await manager.GetByIdAsync(Id);

            return View(analyze);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int Id)
        {
            try
            {
                var analyze = await manager.GetByIdAsync(Id);
                await manager.DeleteAsync(analyze);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }

    }
}