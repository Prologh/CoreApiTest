using HeroCore.Api.Data.Context;
using HeroCore.Api.Models;
using HeroCore.Api.Repositories.Abstract;

namespace HeroCore.Api.Repositories
{
    public class QuestRepository : EntityBaseRepository<Quest>, IQuestRepository
    {
        public QuestRepository(ApiDbContext context)
            : base(context)
        { }
    }
}
