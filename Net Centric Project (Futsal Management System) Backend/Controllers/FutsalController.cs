using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net_Centric_Project__Futsal_Management_System__Backend.DTOs;

namespace Net_Centric_Project__Futsal_Management_System__Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutsalController : ControllerBase
    {
        private readonly FutsalManagementDBContext dbContext;

        public FutsalController(
            FutsalManagementDBContext dbContext
        )
        {
            this.dbContext = dbContext;
        }

        [HttpPost("AddFutsal")]
        public async Task<ActionResult<String>> Register(AddFutsalDTO addFutsal)
        { 

            try
            {
                var adminFromDb = await dbContext.Admins.FindAsync(addFutsal.AdminId);

                if (adminFromDb == null)
                {
                    return NotFound("Admin Not Found");
                }

                var futsal = new Futsal
                {
                    FutsalDescription = addFutsal.FutsalDescription,
                    FutsalEndTime = addFutsal.FutsalEndTime,
                    FutsalLocation = addFutsal.FutsalLocation,
                    FutsalName = addFutsal.FutsalName,
                    BasePrice = addFutsal.BasePrice,
                    FutsalStartTime = addFutsal.FutsalStartTime,
                    admin = adminFromDb,
                    AdminId = addFutsal.AdminId,
                };

                await dbContext.Futsals.AddAsync(futsal);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception err)
            {
                    return BadRequest(err.InnerException.Message);
            }
            return Ok("Futsal Successfully Added");
        }

        [HttpGet]
        public async Task<ActionResult<List<Futsal>>> Get(int adminId)
        {
            var futsalForAdmins = await dbContext.Futsals
                .Where(c => c.AdminId == adminId)
                .ToListAsync();

            return futsalForAdmins;
        }
    }
}
