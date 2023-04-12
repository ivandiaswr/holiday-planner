using AutoMapper;
using DataAccess.Data;
using DataAccess.Dtos;

namespace aspnetserver.Apis
{
    public static class PlanApi
    {
        //public static void ConfigureApi(this WebApplication app)
        //{
        //    app.MapGet("api/v1/plans", async () => GetAllPlans);
        //    //app.MapGet("/Plans/{id}", () => GetPlan);
        //    //app.MapPost("/Plans/", () => InsertPlan);
        //    //app.MapPut("/Plans/", () => UpdatePlan);
        //    //app.MapDelete("/Plans/", () => DeletePlan);
        //}

        //private static async Task<IResult> GetAllPlans(IPlanRepository repo, IMapper mapper)
        //{
        //    try
        //    {
        //        var plans = await repo.GetAllPlans();

        //        return Results.Ok(mapper.Map<IEnumerable<PlanReadDto>>(plans));
        //    }
        //    catch (Exception e)
        //    {
        //        return Results.Problem(e.Message);
        //    }
        //}

        //private static async Task<IResult> GetPlan(int id, IPlanRepository data)
        //{
        //    try
        //    {
        //        return Results.Ok(await data.GetPlan(id));
        //    }
        //    catch (Exception e)
        //    {
        //        return Results.Problem(e.Message);
        //    }
        //}

        //private static async Task<IResult> InsertPlan(Plan plan, IPlanRepository data)
        //{
        //    try
        //    {
        //        return Results.Ok(await data.InsertPlan(plan));
        //    }
        //    catch (Exception e)
        //    {
        //        return Results.Problem(e.Message);
        //    }
        //}

        //private static async Task<IResult> UpdatePlan(Plan plan, IPlanRepository data)
        //{
        //    try
        //    {
        //        return Results.Ok(await data.UpdatePlan(plan));
        //    }
        //    catch (Exception e)
        //    {
        //        return Results.Problem(e.Message);
        //    }
        //}

        //private static async Task<IResult> DeletePlan(Plan plan, IPlanRepository data)
        //{
        //    try
        //    {
        //        return Results.Ok(await data.DeletePlan(plan));
        //    }
        //    catch (Exception e)
        //    {
        //        return Results.Problem(e.Message);
        //    }
        //}
    }
}
