using Analysis.Data.AppDbContext;
using Analysis.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Analysis.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrugsController : ControllerBase
    {

        private readonly AnalysisDbContext _analysisDbContext;


        public DrugsController(AnalysisDbContext analysisDbContext)
        {
            _analysisDbContext = analysisDbContext;

        }



        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Drug>>> GetDrugs()
        {
            return await _analysisDbContext.Drugs.ToListAsync();
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Drug>> GetDrug(int id)
        {

            var drug = await _analysisDbContext.Drugs.FirstOrDefaultAsync(x => x.Id == id);

            if (drug != null)
            {
                return Ok(drug);
            }
            else
            {
                return NotFound();
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrug(int id, Drug drug)
        {
            if (id != drug.Id)
            {
                return BadRequest();
            }

            _analysisDbContext.Entry(drug).State = EntityState.Modified;

            try
            {
                await _analysisDbContext.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                var databaseValues = entry.GetDatabaseValues();
                var clientValues = entry.Entity;

                if (databaseValues == null)
                {
                    return NotFound();
                }
                else
                {
                    var message = "The operation failed. The drug may have been updated by another user. " +
                                    "Please check the latest version of the drug and try again.";

                    return Conflict(message);
                }
            }

            return NoContent();
        }


        [HttpPost("[action]")]
        public async Task<ActionResult<Drug>> PostDrug(Drug drug)

        {
            _analysisDbContext.Drugs.Add(drug);
            var result = _analysisDbContext.SaveChanges();
            if (result > 0)
            {
                return CreatedAtAction("GetDrug", new { Id = drug.Id }, drug);
            }
            else
            {
                return Problem("Product could not be added:(");
            }

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrug(int id)
        {
            try
            {
                var drug = await _analysisDbContext.Drugs.FindAsync(id);
                if (drug == null)
                {
                    return NotFound();
                }

                _analysisDbContext.Drugs.Remove(drug);
                await _analysisDbContext.SaveChangesAsync();
                return Ok();
            }


            catch (DbUpdateConcurrencyException ex)
            {
                var databaseDrug = await _analysisDbContext.Drugs.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);
                if (databaseDrug == null)
                {
                    return NotFound("The drug may have been deleted by another user.");
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {

                var sqlexception = (SqlException)ex.InnerException;
                if (sqlexception.Number == 547)
                {
                    return Problem("The record cannot be deleted because it is associated with another record.");
                }
                else
                {
                    return Problem(ex.Message);
                }

            }
            return NoContent();
        }

    }
}

