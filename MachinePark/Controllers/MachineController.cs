using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MachinePark.Data;

namespace MachinePark.Controllers
{
    [Route("machines")]
    [ApiController]
    public class MachineController : Controller
    {
        private readonly MachineParkContext _db;

        public MachineController(MachineParkContext db) => _db = db;

        [HttpGet]
        public async Task<ActionResult<List<Machine>>> GetMachines()
        {
            return (await _db.Machines.ToListAsync());
        }
    }
}
