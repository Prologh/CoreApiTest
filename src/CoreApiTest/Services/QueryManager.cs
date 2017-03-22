using System.Linq;
using Microsoft.EntityFrameworkCore;

using CoreApiTest.Data.Context;
using CoreApiTest.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CoreApiTest.Services
{
    public static class QueryManager
    {
        public async static Task<List<Hero>> HeroFull(this ApiDbContext context)
        {
            return await context.HeroItems
                .Include(h => h.Quests)
                .ToListAsync();
        }

        public async static Task<List<Quest>> QuestFull(this ApiDbContext context)
        {
            return await context.QuestItems
                .Include(q => q.Hero)
                .ToListAsync();
        }
    }
}
