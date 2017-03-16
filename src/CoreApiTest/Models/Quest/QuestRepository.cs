using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CoreApiTest.Data.Context;
using CoreApiTest.Services;

namespace CoreApiTest.Models.Quest
{
    public class QuestRepository : IQuestRepository
    {

        private readonly HeroContext _context;

        public QuestRepository(HeroContext context)
        {
            _context = context;
        }

        public async Task<List<Quest>> GetAll()
        {
            return await _context.QuestFull().ToListAsync();
        }

        public async Task<Quest> GetById(int? id)
        {
            return await _context.QuestFull().FirstOrDefaultAsync(q => q.IdQuest == id);
        }

        public async Task Add(Quest item)
        {
            var hero = await _context.HeroItems.FirstOrDefaultAsync(h => h.IdHero == item.IdHero);
            if (hero != null)
            {
                hero.Quests.Add(item);
                _context.Update(hero);
                item.Hero = hero;
            }
            _context.QuestItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Quest item)
        {
            var hero = await _context.HeroItems.FirstOrDefaultAsync(h => h.IdHero == item.IdHero);
            if (hero != null)
            {
                hero.Quests.Add(item);
                _context.Update(hero);
            }
            _context.QuestItems.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Quest item)
        {
            var hero = await _context.HeroItems.FirstOrDefaultAsync(h => h.IdHero == item.IdHero);
            if (hero != null)
            {
                hero.Quests.Remove(item);
                _context.HeroItems.Update(hero);
            }
            _context.QuestItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
