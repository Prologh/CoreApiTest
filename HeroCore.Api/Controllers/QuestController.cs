using AutoMapper;
using HeroCore.Api.Models;
using HeroCore.Api.Repositories.Abstract;
using HeroCore.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroCore.Api.Controllers
{
    [Route("api/[controller]")]
    public class QuestController : Controller
    {

        public QuestController(IQuestRepository questItems)
        {
            _questItems = questItems;
        }
        private IQuestRepository _questItems { get; set; }

        // GET api/<controller>
        [HttpGet(Name = "GetAllQuestes")]
        public async Task<IActionResult> GetAll()
        {
            var questList = await _questItems.AllIncluding(q => q.Hero);
            var questListVM = Mapper.Map<IEnumerable<Quest>, IEnumerable<QuestViewModel>>(questList);
            return new OkObjectResult(questListVM);
        }

        // GET api/<controller>/{id}
        [HttpGet("{id}", Name = "GetQuestById")]
        public async Task<IActionResult> GetById(int id)
        {
            var quest = await _questItems.GetSingle(q => q.Id == id, q => q.Hero);
            if (quest == null)
            {
                return new NotFoundResult();
            }
            var questVM = Mapper.Map<Quest, QuestViewModel>(quest);
            return new ObjectResult(questVM);
        }

        // GET api/<controller>/{id}/hero
        [HttpGet("{id}/hero", Name = "GetQuestOwner")]
        public async Task<IActionResult> GetQuestOwner(int id)
        {
            var quest = await _questItems.GetSingle(q => q.Id == id, q => q.Hero);
            if (quest == null)
            {
                return new NotFoundResult();
            }
            return new RedirectToRouteResult("GetHeroById",
                new { controller = "Hero", id = quest.HeroId });
        }

        // POST api/<controller>
        [HttpPost(Name = "CreateQuest")]
        public async Task<IActionResult> Create([FromBody] Quest item)
        {
            if (!ModelState.IsValid || item == null)
            {
                return new BadRequestResult();
            }
            var newQuest = new Quest()
            {
                Title = item.Title,
                IsCompleted = item.IsCompleted,
                HeroId = item.HeroId,
            };
             _questItems.Add(newQuest);
            await _questItems.Commit();

            var newQuestVM = Mapper.Map<Quest, QuestViewModel>(newQuest);

            return new CreatedAtRouteResult("GetQuestById",
                new { controller = "Quest", id = item.Id }, newQuestVM);
        }

        // PUT api/<controller>
        [HttpPut("{id}", Name = "UpdateQuest")]
        public async Task<IActionResult> Update(int id, [FromBody] Quest item)
        {
            if (!ModelState.IsValid || item == null)
            {
                return new BadRequestResult();
            }
            var quest = await _questItems.GetSingle(id);
            if (quest == null)
            {
                return new NotFoundResult();
            }
            quest.Title = item.Title;
            quest.IsCompleted = item.IsCompleted;
            quest.HeroId = item.HeroId;

            _questItems.Update(quest);
            await _questItems.Commit();
            return new OkResult();
        }

        // DELETE api/<controller>/{id}
        [HttpDelete("{id}", Name = "DeleteQuest")]
        public async Task<IActionResult> Delete(int id)
        {
            var quest = await _questItems.GetSingle(id);
            if (quest == null)
            {
                return new NotFoundResult();
            }
            _questItems.Delete(quest);
            await _questItems.Commit();
            return new OkResult();
        }
    }
}
