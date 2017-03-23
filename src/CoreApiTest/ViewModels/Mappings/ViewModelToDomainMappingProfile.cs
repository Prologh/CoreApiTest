using AutoMapper;
using CoreApiTest.Models;

namespace CoreApiTest.ViewModels.Mappings
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
