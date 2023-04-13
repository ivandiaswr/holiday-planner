using DataAccess.Models;

namespace aspnetserver.Data
{
    public interface IPlanRepository
    {
        Task SaveChangesAsync();
        Task<IEnumerable<Plan>> GetAllPlansAsync();
        Task<Plan> GetPlanByIdAsync(int id);
        Task CreatePlanAsync(Plan plan);
        //Task UpdatePlan(Plan plan); Its done directly through EF this method is not needed
        void DeletePlan(Plan plan);
        
    }
}
