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

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<Hero> GetAll()
        {
            return _context.HeroItems.ToList();
        }

        // GET api/<controller>/{id}
        [HttpGet("{id}")]
        public Hero GetById(int id)
        {
            return _context.HeroItems.FirstOrDefault(q => q.Id == id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Create(Hero item)
        {
            _context.HeroItems.Add(item);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async void Update(Hero item)
        {
            //if ()

            _context.HeroItems.Update(item);
            //await _context.SaveChangesAsync(item);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
