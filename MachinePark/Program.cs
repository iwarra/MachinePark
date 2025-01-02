using MachinePark.Data;
using Microsoft.EntityFrameworkCore;
using MachinePark.Shared.Services;

namespace MachinePark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services for API
            builder.Services.AddControllers();

            // Configure the database context (SQLite)
            builder.Services.AddSqlite<MachineParkContext>("Data Source=machine.db");

            // Add services for your MachineService (backend logic)
            builder.Services.AddScoped<MachineService>();

            // Configure HttpClient if needed (used by your services or components)
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7207/") });

            // Build the application
            var app = builder.Build();

            // Configure the HTTP request pipeline for API calls
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // Use HTTPS and static files for server-side components
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Add routing for controllers (API)
            app.UseRouting();
            app.MapControllers();

            // Initialize the database and run migrations
            var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<MachineParkContext>();
                if (db.Database.GetPendingMigrations().Any())
                {
                    db.Database.Migrate();
                }
                // Seed initial data if needed
                SeedData.Initialize(db);
            }

            // Run the application
            app.Run();
        }
    }
}
