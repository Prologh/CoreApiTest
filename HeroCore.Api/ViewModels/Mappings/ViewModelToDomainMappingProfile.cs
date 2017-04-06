using AutoMapper;
using HeroCore.Api.Models;

namespace HeroCore.Api.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<HeroViewModel, Hero>();
            Mapper.CreateMap<QuestViewModel, Quest>();
        }
    }
}
