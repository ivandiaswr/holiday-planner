using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    public class PlanRepository : IPlanRepository
    {
        private readonly HolidayPlannerDbContext _dbContext;

        public PlanRepository(HolidayPlannerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Plan>> GetAllPlansAsync()
        {
            try
            {
                var plans = await _dbContext.Plans.ToListAsync();

                if (plans is null)
                {
                    throw new Exception("Plans not Found");
                }

                return plans;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Plan> GetPlanByIdAsync(int id)
        {
            try
            {
                var plan = await _dbContext.Plans.FirstOrDefaultAsync(x => x.Id == id);

                if (plan is null)
                {
                    throw new Exception("Plan not Found");
                }

                return plan;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task CreatePlanAsync(Plan plan)
        {
            try
            {
                await _dbContext.AddAsync(plan);
                await SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new ArgumentException(nameof(plan), e.Message);
            }
        }

        public void DeletePlan(Plan plan)
        {
            try
            {
                _dbContext.Remove(plan);
            }
            catch (Exception e)
            {
                throw new ArgumentException(nameof(plan), e.Message);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
