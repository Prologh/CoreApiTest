using AutoMapper;
using HeroCore.Api.Models;
using System.Linq;

namespace HeroCore.Api.ViewModels.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Hero, HeroViewModel>()
                .ForMember(vm => vm.Quests,
                    map => map.MapFrom(h => h.Quests.Count));
            CreateMap<Quest, QuestViewModel>();
        }
    }
}
