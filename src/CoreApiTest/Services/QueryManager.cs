using System.Linq;
using Microsoft.EntityFrameworkCore;

using CoreApiTest.Data.Context;
using CoreApiTest.Models;

namespace CoreApiTest.Services
{
    public static class QueryManager
    {
        //public static IQueryable<T> SetFull(this ApiDbContext context)
        //{
        //    return context.
        //}

        public static IQueryable<Hero> HeroFull(this ApiDbContext context)
        {
            return context.HeroItems
                .Include(h => h.Quests);
        }

        public static IQueryable<Quest> QuestFull(this ApiDbContext context)
        {
            return context.QuestItems
                .Include(q => q.Hero);
        }
    }
}
