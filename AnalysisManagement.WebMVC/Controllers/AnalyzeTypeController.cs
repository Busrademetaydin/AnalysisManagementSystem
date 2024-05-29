using Analysis.Business.Abstract;
using Analysis.Entities.Concrete;
using AnalysisManagement.WebMVC.Models.Entity;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisManagement.WebMVC.Controllers
{

    [Authorize]
    public class AnalyzeTypeController : Controller
    {
        private readonly IAnalyzeTypeManager analyzeTypeManager;
        private readonly INotyfService notyf;
        private readonly IMapper mapper;

        public AnalyzeTypeController(IAnalyzeTypeManager analyzeTypeManager, INotyfService notyf, IMapper mapper)

        {
            this.analyzeTypeManager = analyzeTypeManager;
            this.notyf = notyf;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var analyzeType = await analyzeTypeManager.GetAllAsync();

                return View(analyzeType);
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }

        public async Task<IActionResult> Insert()
        {
            AnalyzeTypeInsertVM insertVM = new();
            return View(insertVM);
        }

        //public async Task<ActionResult> Details(int id)
        //{

        //    var analyzeType = await analyzeTypeManager.GetByIdAsync(id);
        //    if (analyzeType == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(analyzeType);
        //}
        public ActionResult Details(int id)
        {
            var analyzeType = analyzeTypeManager.GetByIdAsync(id).Result;

            if (analyzeType == null)
            {
                return NotFound();
            }


            return View(analyzeType);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var result = await analyzeTypeManager.GetByIdAsync(id);
            var update = mapper.Map<AnalyzeTypeUpdateVM>(result);

            return View(update);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AnalyzeTypeUpdateVM updateVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var analyze = mapper.Map<AnalyzeType>(updateVM);
                    await analyzeTypeManager.UpdateAsync(analyze);
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
            var analyzeType = await analyzeTypeManager.GetByIdAsync(Id);

            return View(analyzeType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int Id)
        {
            try
            {
                var analyzeType = await analyzeTypeManager.GetByIdAsync(Id);
                await analyzeTypeManager.DeleteAsync(analyzeType);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }
    }
}
