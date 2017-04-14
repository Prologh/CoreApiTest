using HeroCore.Api.Data.Context;
using HeroCore.Api.Models;
using HeroCore.Api.Repositories.Abstract;

namespace HeroCore.Api.Repositories
{
    public class HeroRepository : EntityBaseRepository<Hero>, IHeroRepository
    {
        public HeroRepository(ApiDbContext context) : base(context) { }
    }
}
