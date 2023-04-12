using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class HolidayPlannerDbContext : DbContext
    {
        public HolidayPlannerDbContext(DbContextOptions<HolidayPlannerDbContext> options) : base(options) { }
        public DbSet<Plan> Plans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Plan> plansToSeed = new List<Plan>();

            for (int i = 1; i <= 6; i++)
            {
                plansToSeed.Add(new Plan
                {
                    Id = i,
                    Name = "Name" + i.ToString(),
                    Place = "Place" + i.ToString(),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    AddicionalInformation = "",
                });
            }

            modelBuilder.Entity<Plan>().HasData(plansToSeed);
        }
    }
}
