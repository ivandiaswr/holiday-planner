using aspnetserver.Data;
using AutoMapper;
using DataAccess.Dtos.Plan;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HolidayPlannerDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPlanRepository, PlanRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // Register AutoMapper

builder.Services.AddCors( p => p.AddPolicy("CORSPolicy", build =>
{
    build.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000", "https://victorious-plant-0f4deba03.3.azurestaticapps.net");
}));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1"));

app.UseHttpsRedirection();

// After HttpRedirection
app.UseCors("CORSPolicy");

// Map Endpoints
//app.ConfigureApi();

// Plan

app.MapGet("api/v1/plans", async (IPlanRepository repo, IMapper mapper) =>
{
    var plans = await repo.GetAllPlansAsync();

    return Results.Ok(mapper.Map<IEnumerable<PlanReadDto>>(plans));
}).WithTags("Plan Endpoints");

app.MapGet("api/v1/plans/{id}", async (IPlanRepository repo, IMapper mapper, int id) =>
{
    var plan = await repo.GetPlanByIdAsync(id);

    if (plan is not null)
    {
        return Results.Ok(mapper.Map<PlanReadDto>(plan));
    }

    return Results.NotFound();
}).WithTags("Plan Endpoints");

app.MapPost("api/v1/plans", async (IPlanRepository repo, IMapper mapper, PlanCreateDto planCreateDto) =>
{
    var newPlan = mapper.Map<Plan>(planCreateDto);

    await repo.CreatePlanAsync(newPlan);

    var planReadDto = mapper.Map<PlanReadDto>(newPlan);

    return Results.Created($"api/v1/plans/{planCreateDto.Id}", planCreateDto);

}).WithTags("Plan Endpoints");

app.MapPut("api/v1/plans/{id}", async (IPlanRepository repo, IMapper mapper, int id, PlanUpdateDto planUpdateDto) =>
{
    var plan = await repo.GetPlanByIdAsync(id);

    if (plan is null)
    {
        return Results.NotFound();
    }

    mapper.Map(planUpdateDto, plan);

    await repo.SaveChangesAsync();

    return Results.NoContent();
}).WithTags("Plan Endpoints");

app.MapDelete("api/v1/plans/{id}", async (IPlanRepository repo, IMapper mapper, int id) =>
{
    var planDelete = await repo.GetPlanByIdAsync(id);

    if (planDelete is null)
    {
        return Results.NotFound();
    }

    repo.DeletePlan(planDelete);

    await repo.SaveChangesAsync();

    return Results.NoContent();
}).WithTags("Plan Endpoints");

// User

//app.MapGet("api/v1/users", async (IUserRepository repo, IMapper mapper) =>
//{
//    var users = await repo.GetAllUsersAsync();

//    return Results.Ok(mapper.Map<IEnumerable<UserReadDto>>(users));
//}).WithTags("User Endpoints");

//app.MapGet("api/v1/users/{id}", async (IUserRepository repo, IMapper mapper, int id) =>
//{
//    var user = await repo.GetUserByIdAsync(id);

//    if (user is not null)
//    {
//        return Results.Ok(mapper.Map<UserReadDto>(user));
//    }

//    return Results.NotFound();
//}).WithTags("User Endpoints");

//app.MapPost("api/v1/users", async (IUserRepository repo, IMapper mapper, UserCreateDto userCreateDto) =>
//{
//    var newUser = mapper.Map<User>(userCreateDto);

//    await repo.CreateUserAsync(newUser);

//    var planReadDto = mapper.Map<UserReadDto>(newUser);

//    return Results.Created($"api/v1/users/{userCreateDto.Id}", userCreateDto);

//}).WithTags("User Endpoints");

//app.MapPut("api/v1/users/{id}", async (IUserRepository repo, IMapper mapper, int id, UserUpdateDto userUpdateDto) =>
//{
//    var user = await repo.GetUserByIdAsync(id);

//    if (user is null)
//    {
//        return Results.NotFound();
//    }

//    mapper.Map(userUpdateDto, user);

//    await repo.SaveChangesAsync();

//    return Results.NoContent();
//}).WithTags("User Endpoints");

//app.MapDelete("api/v1/users/{id}", async (IUserRepository repo, IMapper mapper, int id) =>
//{
//    var userDelete = await repo.GetUserByIdAsync(id);

//    if (userDelete is null)
//    {
//        return Results.NotFound();
//    }

//    repo.DeleteUser(userDelete);

//    await repo.SaveChangesAsync();

//    return Results.NoContent();
//}).WithTags("User Endpoints");


app.Run();