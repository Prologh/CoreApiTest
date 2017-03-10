using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return await _context.HeroItems.ToListAsync();
        }

        public async Task<Hero> GetById(int id)
        {
            return await _context.HeroItems.FirstOrDefaultAsync(q => q.HeroId == id);
        }

        public async Task Add(Hero item)
        {
            _context.HeroItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Hero item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        // DELETE api/<controller>/5
        public async Task Delete(int id)
        {
            _context.HeroItems.Remove(await _context.HeroItems.FirstAsync(t => t.HeroId == id));
            await _context.SaveChangesAsync();
        }
    }
}
