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
    public class AnalyzeDetailController : Controller
    {
        private readonly IAnalyzeTypeManager analyzeTypeManager;
        private readonly IAnalyzeDetailManager analyzeDetailManager;
        private readonly IAnalysisManager manager;
        private readonly INotyfService notyf;
        private readonly IMapper mapper;


        public AnalyzeDetailController(IAnalyzeDetailManager analyzeDetailManager, IAnalysisManager manager, INotyfService notyf, IMapper mapper)

        {
            this.analyzeDetailManager = analyzeDetailManager;
            this.analyzeTypeManager = analyzeTypeManager;
            this.manager = manager;
            this.notyf = notyf;
            this.mapper = mapper;



        }

        public async Task<IActionResult> Index()
        {

            try
            {
                var analyzeDetails = await analyzeDetailManager.GetAllAsync();

                return View(analyzeDetails);
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }

        public async Task<IActionResult> InsertAsync()
        {
            AnalyzeDetailInsertVM insertVM = new();
            return View(insertVM);
        }

        public async Task<ActionResult> DetailsAsync(int id)
        {


            var analyzeDetail = await analyzeDetailManager.GetByIdAsync(id);
            if (analyzeDetail == null)
            {
                return NotFound();
            }
            return View(analyzeDetail);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(AnalyzeDetailInsertVM analyzeDetail)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var analyze = await manager.GetByIdAsync(analyzeDetail.AnalyzeId);
                    if (analyze != null)
                    {

                        if (analyze != null)
                        {

                            var analyzeType = await analyzeTypeManager.GetByIdAsync(analyze.AnalyzeTypeId);
                            if (analyzeType != null)
                            {
                                analyzeDetail.AnalyzeType = analyzeType.Name;
                            }
                            else
                            {
                                notyf.Error("AnalyzeType not found for the given AnalyzeId.");

                            }
                        }
                        else
                        {
                            notyf.Error("Analyze not found.");

                        }

                    }

                    var analysisDetail = mapper.Map<AnalyzeDetail>(analyzeDetail);

                    analyzeDetailManager.SetLimit(analysisDetail, analyzeDetail.Limit, analyzeDetail.AnalyzeType);

                    await analyzeDetailManager.InsertAsync(analysisDetail);

                    notyf.Success("Analyze detail successfully inserted!");
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    notyf.Error("Error inserting analyze detail.");
                }
            }
            return View(analyzeDetail);
        }

        public async Task<IActionResult> Edit(int id)
        {

            var analyzeDetail = await analyzeDetailManager.GetByIdAsync(id);
            if (analyzeDetail == null)
            {
                return NotFound();
            }

            var analyze = await manager.GetByIdAsync(analyzeDetail.AnalyzeId);
            var updateVM = mapper.Map<AnalyzeDetailUpdateVM>(analyzeDetail);
            if (analyze != null)
            {
                updateVM.AnalyzeType = analyze.AnalyzeType?.Name;
            }


            return View(updateVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AnalyzeDetailUpdateVM updateVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var analyzeDetail = mapper.Map<AnalyzeDetail>(updateVM);
                    analyzeDetailManager.SetLimit(analyzeDetail, updateVM.Limit, updateVM.AnalyzeType);
                    await analyzeDetailManager.UpdateAsync(analyzeDetail);
                    notyf.Success("Analyze detail successfully updated!");
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    notyf.Error("Error updating analyze detail.");
                    return View(updateVM);
                }
            }
            return View(updateVM);

        }

        public async Task<IActionResult> DeleteAsync(int Id)
        {

            var analyzeDetail = await analyzeDetailManager.GetByIdAsync(Id);
            if (analyzeDetail == null)
            {
                return NotFound();
            }
            return View(analyzeDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int Id)
        {

            try
            {
                var analyzeDetail = await analyzeDetailManager.GetByIdAsync(Id);
                if (analyzeDetail == null)
                {
                    return NotFound();
                }
                await analyzeDetailManager.DeleteAsync(analyzeDetail);
                notyf.Success("Analyze detail successfully deleted!");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                notyf.Error("Error deleting analyze detail.");
                return View();
            }
        }

    }
}