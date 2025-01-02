using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MachinePark.Data;
using MachinePark.Shared.Models;

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachine(Guid id)
        {
            // Find the machine in the database
            var machine = await _db.Machines.FindAsync(id);

            if (machine == null)
            {
                // Return 404 if the machine doesn't exist
                return NotFound(new { Message = $"Machine with ID {id} not found." });
            }

            // Remove the machine from the database
            _db.Machines.Remove(machine);

            // Save the changes
            await _db.SaveChangesAsync();

            // Return 204 No Content on successful deletion
            return NoContent();
        }

    }
}
