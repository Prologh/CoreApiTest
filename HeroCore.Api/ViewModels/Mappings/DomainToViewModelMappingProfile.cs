using AutoMapper;
using HeroCore.Api.Models;
using System.Linq;

namespace HeroCore.Api.ViewModels.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Hero, HeroViewModel>()
                .ForMember(vm => vm.Quests,
                    map => map.MapFrom(h => h.Quests.Count()));
            Mapper.CreateMap<Quest, QuestViewModel>();
        }
    }
}
