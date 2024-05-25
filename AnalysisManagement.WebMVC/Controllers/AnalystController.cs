using Analysis.Business.Abstract;
using Analysis.Data.AppDbContext;
using Analysis.Entities.Concrete;
using AnalysisManagement.WebMVC.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisManagement.WebMVC.Controllers
{
    public class AnalystController : Controller
    {
        private readonly IAnalystManager manager;
        private readonly INotyfService notyf;
        private readonly IMapper mapper;

        private AnalysisDbContext db = new AnalysisDbContext();

        public ActionResult GetAnalysts(string term)
        {
            var analysts = db.Analysts
                .Where(a => a.FirstName.Contains(term))
                .Select(a => new { id = a.Id, label = a.FirstName })
                .ToList();

            return Json(analysts);

        }

        public AnalystController(IAnalystManager manager, INotyfService notyf, IMapper mapper)
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

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> InsertAsync()
        {
            AnalystInsertVM analyst = new();
            return View(analyst);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(AnalystInsertVM analyst)
        {
            if (ModelState.IsValid)
            {
                Analyst analyst1 = new()
                {
                    FirstName = analyst.FirstName,
                    LastName = analyst.LastName,
                    Gender = analyst.Gender,
                    Email = analyst.Email,
                    Title = analyst.Title,
                    Phone = analyst.Phone,
                    IdentificationNumber = analyst.IdentificationNumber

                };

                try
                {
                    var result = await manager.InsertAsync(analyst1);
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

        public ActionResult Details(int id)
        {
            var analyst = manager.GetByIdAsync(id).Result;

            if (analyst == null)
            {
                return NotFound();
            }


            return View(analyst);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var result = await manager.GetByIdAsync(id);
            var update = mapper.Map<AnalystUpdateVM>(result);


            return View(update);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AnalystUpdateVM updateVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var analyst = mapper.Map<Analyst>(updateVM);
                    manager.UpdateAsync(analyst);
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
            var analyst = await manager.GetByIdAsync(Id);

            return View(analyst);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int Id)
        {
            try
            {
                var analyst = await manager.GetByIdAsync(Id);
                await manager.DeleteAsync(analyst);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }
    }
}


