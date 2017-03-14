using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CoreApiTest.Models.Hero;

namespace CoreApiTest.Controllers
{
    [Route("api/[controller]")]
    public class HeroController : Controller
    {

        public HeroController(IHeroRepository heroItems)
        {
            _heroItems = heroItems;
        }
        private IHeroRepository _heroItems { get; set; }

        // GET api/<controller>
        [HttpGet(Name = "GetAllHeroes")]
        public async Task<IEnumerable<Hero>> GetAll()
        {
            return await _heroItems.GetAll();
        }

        // GET api/<controller>/{id}
        [HttpGet("{id}", Name = "GetHeroById")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _heroItems.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // GET api/<controller>/{id}/quest
        [HttpGet("{id}/quest", Name = "GetAllHeroQuests")]
        public async Task<IActionResult> GetAllHeroQuests(int id)
        {
            var item = await _heroItems.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
            //return new ObjectResult(item.Quests);
            //return new ObjectResult(item.Quests.ToList());
        }

        // POST api/<controller>
        [HttpPost(Name = "CreateHero")]
        public async Task<IActionResult> Create([FromBody] Hero item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await _heroItems.Add(item);
            return CreatedAtRoute("GetHeroById", new { id = item.IdHero }, item);
        }

        // PUT api/<controller>
        [HttpPut("{id}", Name = "UpdateHero")]
        public async Task<IActionResult> Update(int id, [FromBody] Hero item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var hero = await _heroItems.GetById(id);
            if (hero == null)
            {
                return NotFound();
            }
            hero.Name = item.Name;
            hero.IsRetired = item.IsRetired;
            hero.Quests = item.Quests;
            await _heroItems.Update(hero);
            return Ok();
        }

        // DELETE api/<controller>/{id}
        [HttpDelete("{id}", Name = "DeleteHero")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _heroItems.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            await _heroItems.Delete(id);
            return Ok();
        }
    }
}
