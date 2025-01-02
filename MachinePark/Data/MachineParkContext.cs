using MachinePark.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace MachinePark.Data
{
    public class MachineParkContext : DbContext
    {
        public MachineParkContext(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<Machine> Machines { get; set; }
    }
}
