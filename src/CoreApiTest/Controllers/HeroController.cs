using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CoreApiTest.Models;
using CoreApiTest.Repositories.Abstract;
using AutoMapper;
using CoreApiTest.ViewModels;

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
        public async Task<IActionResult> GetAll()
        {
            //return await _heroItems.AllIncluding(h => h.Quests)
            //return await _heroItems.GetAll();

            var heroList = await _heroItems.AllIncluding(h => h.Quests);
            var heroListVM = Mapper.Map<IEnumerable<Hero>, IEnumerable<HeroViewModel>>(heroList);
            return new OkObjectResult(heroListVM);
        }

        // GET api/<controller>/{id}
        [HttpGet("{id}", Name = "GetHeroById")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _heroItems.GetSingle(id);
            //var item = await _heroItems.GetSingle(h => h.Id == id, h => h.Quests);
            if (item == null)
            {
                return new NotFoundResult();
            }
            return new ObjectResult(item);
        }

        // GET api/<controller>/{id}/quest
        [HttpGet("{id}/quest", Name = "GetAllHeroQuests")]
        public async Task<IActionResult> GetAllHeroQuests(int id)
        {
            //var item = await _heroItems.GetSingle(h => h.Id == id, h => h.Quests);
            var item = await _heroItems.GetSingle(id);
            if (item == null)
            {
                return new NotFoundResult();
            }
            return new ObjectResult(item.Quests);
        }

        // POST api/<controller>
        [HttpPost(Name = "CreateHero")]
        public async Task<IActionResult> Create([FromBody] Hero item)
        {
            if (!ModelState.IsValid || item == null)
            {
                return new BadRequestResult();
            }
            var newHero = new Hero()
            {
                Name = item.Name,
                IsRetired = item.IsRetired,
            };
            _heroItems.Add(newHero);
            await _heroItems.Commit();
            return CreatedAtRoute("GetHeroById",
                new { controller = "Hero", id = item.Id }, newHero);
        }

        // PUT api/<controller>
        [HttpPut("{id}", Name = "UpdateHero")]
        public async Task<IActionResult> Update(int id, [FromBody] Hero item)
        {
            if (!ModelState.IsValid || item == null)
            {
                return new BadRequestResult();
            }
            var hero = await _heroItems.GetSingle(id);
            if (hero == null)
            {
                return new NotFoundResult();
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
                return new NotFoundResult();
            }
            _heroItems.Delete(item);
            await _heroItems.Commit();
            return Ok();
        }
    }
}
