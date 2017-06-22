using AutoMapper;
using HeroCore.Api.Models;

namespace HeroCore.Api.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<HeroViewModel, Hero>();
            CreateMap<QuestViewModel, Quest>();
        }
    }
}
