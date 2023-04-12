using AutoMapper;
using DataAccess.Dtos.Plan;
using DataAccess.Models;

namespace DataAccess.Profiles
{
    public  class PlansProfile : Profile // AutoMapper
    {
        public PlansProfile()
        {
            // Source -> Target
            CreateMap<Plan, PlanReadDto>();
            CreateMap<PlanCreateDto, Plan>();
            CreateMap<PlanUpdateDto, Plan>();
        }
    }
}
