using CoreApiTest.Data.Context;
using CoreApiTest.Models;
using CoreApiTest.Repositories.Abstract;
using CoreApiTest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiTest.Repositories
{
    public class HeroRepository : EntityBaseRepository<Hero>, IHeroRepository
    {
        public HeroRepository(ApiDbContext context)
            : base(context)
        { }

        //public async Task<IEnumerable<Hero>> GetAll()
        //{
        //    base._context;
        //    return await _context.HeroFull().ToListAsync();
        //}

        //public async Task<Hero> GetById(int id)
        //{
        //    return await _context.HeroFull().FirstOrDefaultAsync(q => q.Id == id);
        //}

        //public async Task Add(Hero item)
        //{
        //    _context.HeroItems.Add(item);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task Update(Hero item)
        //{
        //    _context.HeroItems.Update(item);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task Delete(Hero item)
        //{
        //    _context.HeroItems.Remove(item);
        //    await _context.SaveChangesAsync();
        //}
    }
}
