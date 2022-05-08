using AutoMapper;
using House_API.Models;
using House_API.ViewModels;

namespace House_API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<House, HouseViewModel>();
            CreateMap<HouseViewModel, House>();
            CreateMap<PostHouseViewModel, House>();
            CreateMap<UpdateHouseViewModel, House>();
        }
    }
}