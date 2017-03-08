using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiTest.Models.Hero
{
    public class HeroRepository : IHeroRepository
    {

        private readonly HeroContext _context;

        public HeroRepository(HeroContext context)
        {
            _context = context;
        }

        public IEnumerable<Hero> GetAll()
        {
            return _context.HeroItems.ToList();
        }

        public Hero GetById(int id)
        {
            return _context.HeroItems.FirstOrDefault(q => q.Id == id);
        }

        public void Add(Hero item)
        {
            _context.HeroItems.Add(item);
            _context.SaveChanges();
        }

        public void Update(Hero item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _context.HeroItems.Remove(_context.HeroItems.First(t => t.Id == id));
            _context.SaveChanges();
        }
    }
}
