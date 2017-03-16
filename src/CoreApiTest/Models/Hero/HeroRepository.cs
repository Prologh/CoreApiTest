using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CoreApiTest.Data.Context;
using CoreApiTest.Services;

namespace CoreApiTest.Models.Hero
{
    public class HeroRepository : IHeroRepository
    {

        private readonly HeroContext _context;

        public HeroRepository(HeroContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hero>> GetAll()
        {
            return await _context.HeroFull().ToListAsync();
        }

        public async Task<Hero> GetById(int id)
        {
            return await _context.HeroFull().FirstOrDefaultAsync(q => q.IdHero == id);
        }

        public async Task Add(Hero item)
        {
            _context.HeroItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Hero item)
        {
            _context.HeroItems.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Hero item)
        {
            _context.HeroItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
