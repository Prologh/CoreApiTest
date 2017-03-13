﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreApiTest.Models.Hero;

namespace CoreApiTest.Models.Quest
{
    public class QuestRepository : IQuestRepository
    {

        private readonly HeroContext _context;

        public QuestRepository(HeroContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Quest>> GetAll()
        {
            return await _context.QuestItems.ToListAsync();
        }

        public async Task<Quest> GetById(int id)
        {
            return await _context.QuestItems.FirstOrDefaultAsync(q => q.QuestId == id);
        }

        public async Task Add(Quest item)
        {
            _context.QuestItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Quest item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.QuestItems.Remove(await _context.QuestItems.FirstAsync(t => t.QuestId == id));
            await _context.SaveChangesAsync();
        }
    }
}
