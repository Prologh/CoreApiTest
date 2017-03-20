using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CoreApiTest.Models;
using CoreApiTest.Repositories.Abstract;

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
            return await _heroItems.AllIncluding();
        }

        // GET api/<controller>/{id}
        [HttpGet("{id}", Name = "GetHeroById")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _heroItems.GetSingle(id);
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
            var item = await _heroItems.GetSingle(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item.Quests);
        }

        // POST api/<controller>
        [HttpPost(Name = "CreateHero")]
        public async Task<IActionResult> Create([FromBody] Hero item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _heroItems.Add(item);
            await _heroItems.Commit();
            return CreatedAtRoute("GetHeroById",
                new { controller = "Hero", id = item.Id }, item);
        }

        // PUT api/<controller>
        [HttpPut("{id}", Name = "UpdateHero")]
        public async Task<IActionResult> Update(int id, [FromBody] Hero item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var hero = await _heroItems.GetSingle(id);
            if (hero == null)
            {
                return NotFound();
            }
            hero.Name = item.Name;
            hero.IsRetired = item.IsRetired;
            _heroItems.Update(hero);
            await _heroItems.Commit();
            return Ok();
        }

        // DELETE api/<controller>/{id}
        [HttpDelete("{id}", Name = "DeleteHero")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _heroItems.GetSingle(id);
            if (item == null)
            {
                return NotFound();
            }
            _heroItems.Delete(item);
            await _heroItems.Commit();
            return Ok();
        }
    }
}
