using Analysis.Data.AppDbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Analysis.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Analyst")]

    public class HPLCEquipmentsController : ControllerBase
    {
        private readonly AnalysisDbContext context;

        public HPLCEquipmentsController(AnalysisDbContext context)
        {
            this.context = context;
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> GetHPLCEquipments()
        {
            //var validity = User.Claims.Where(p => p.Type == "CalibrationDueDate").FirstOrDefault();
            var result = context.HPLCEquipments.ToList();
            return Ok(result);

        }


    }
}
