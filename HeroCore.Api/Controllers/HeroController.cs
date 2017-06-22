using AutoMapper;
using HeroCore.Api.Models;
using HeroCore.Api.Repositories.Abstract;
using HeroCore.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace HeroCore.Api.Controllers
{
    [Route("api/[controller]")]
    public class HeroController : Controller
    {
        private IHeroRepository _heroItems { get; set; }

        public HeroController(IHeroRepository heroItems)
        {
            _heroItems = heroItems;
        }

        // GET api/<controller>/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hero = await _heroItems.GetSingle(h => h.Id == id, h => h.Quests);
            if (hero == null)
            {
                return new NotFoundResult();
            }
            var heroVM = Mapper.Map<Hero, HeroViewModel>(hero);
            return new ObjectResult(heroVM);
        }

        // GET api/<controller>/{id}/quest
        [HttpGet("{id}/quest")]
        public async Task<IActionResult> GetAllHeroQuests(int id)
        {
            var hero = await _heroItems.GetSingle(h => h.Id == id, h => h.Quests);
            if (hero == null)
            {
                return new NotFoundResult();
            }
            var heroVM = Mapper.Map<IEnumerable<Quest>, IEnumerable<QuestViewModel>>(hero.Quests);
            return new ObjectResult(heroVM);
        }

        // POST api/<controller>
        [HttpPost]
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

            var newHeroVM = Mapper.Map<Hero, HeroViewModel>(newHero);

            return new CreatedAtRouteResult("GetHeroById",
                new { controller = "Hero", id = item.Id }, newHeroVM);
        }

        // PUT api/<controller>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Hero item)
        {
            if (!ModelState.IsValid || item == null)
            {
                return new BadRequestResult();
            }
            var heroDb = await _heroItems.GetSingle(id);
            if (heroDb == null)
            {
                return new NotFoundResult();
            }
            heroDb.Name = item.Name;
            heroDb.IsRetired = item.IsRetired;

            _heroItems.Update(heroDb);
            await _heroItems.Commit();
            return new OkResult();
        }

        // DELETE api/<controller>/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var heroDb = await _heroItems.GetSingle(id);
            if (heroDb == null)
            {
                return new NotFoundResult();
            }
            _heroItems.Delete(heroDb);
            await _heroItems.Commit();
            return new OkResult();
        }
    }
}
