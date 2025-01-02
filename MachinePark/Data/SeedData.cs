using MachinePark.Shared.Models;

namespace MachinePark.Data
{
    public class SeedData
    {
        public static void Initialize(MachineParkContext db)
        {
            if (!db.Machines.Any())
            {
                var machines = new Machine[]
                {
                    new Machine { Id = Guid.NewGuid(), Name = "Bulldozer", Data = "No data", Status = "Offline" },
                    new Machine { Id = Guid.NewGuid(), Name = "Excavator", Data = "Other data", Status = "Online" },
                    new Machine { Id = Guid.NewGuid(), Name = "Scraper", Data = "More data", Status = "Online" },
                    new Machine { Id = Guid.NewGuid(), Name = "Crane", Data = "Another data", Status = "Offline" },
                    new Machine { Id = Guid.NewGuid(), Name = "Roller", Data = "Even more data", Status = "Online" }
                };
                db.Machines.AddRange(machines);
                db.SaveChanges();
            }
        }
    }
}
