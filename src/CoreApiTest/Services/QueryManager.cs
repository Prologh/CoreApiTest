using System.Linq;
using Microsoft.EntityFrameworkCore;

using CoreApiTest.Data.Context;
using CoreApiTest.Models.Hero;
using CoreApiTest.Models.Quest;

namespace CoreApiTest.Services
{
    public static class QueryManager
    {
        public static IQueryable<Hero> HeroFull(this HeroContext context)
        {
            return context.HeroItems
                .Include(h => h.Quests);
        }

        public static IQueryable<Quest> QuestFull(this HeroContext context)
        {
            return context.QuestItems
                .Include(q => q.Hero);
        }
    }
}
