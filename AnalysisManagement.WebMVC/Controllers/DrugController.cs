﻿using Analysis.Business.Abstract;
using Analysis.Entities.Concrete;
using AnalysisManagement.WebMVC.Models;
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
            var result = manager.GetAllAsync().Result;
            return View(result);
        }

        public async Task<IActionResult> InsertAsync()
        {
            DrugInsertVM insertVM = new DrugInsertVM();
            return View(insertVM);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(DrugInsertVM drug)
        {
            if (ModelState.IsValid)
            {
                Drug drug1 = new Drug()
                {
                    Id = drug.DrugId,
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
                    await manager.InsertAsync(drug1);
                }
                catch (Exception ex)
                {


                }
                return RedirectToAction("Index");
            }

            return View(drug);
        }

    }
}
