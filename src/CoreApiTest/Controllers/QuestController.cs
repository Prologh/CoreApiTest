using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CoreApiTest.Models;
using CoreApiTest.Repositories.Abstract;
using CoreApiTest.Services;

namespace CoreApiTest.Controllers
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
        public async Task<IEnumerable<Quest>> GetAll()
        {
            //return await _questItems.GetAll();
            IEnumerable<Quest> questList = await _questItems.AllIncluding(q => q.Hero);
            IEnumerable<Quest> questList2 = await _questItems.AllIncluding();
            IEnumerable<Quest> questList3 = await _questItems.GetAll();
            return questList;
        }

        // GET api/<controller>/{id}
        [HttpGet("{id}", Name = "GetQuestById")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _questItems.GetSingle(q => q.Id == id, q => q.Hero);
            //var item = await _questItems.GetSingle(id);
            if (item == null)
            {
                return new NotFoundResult();
            }
            return new ObjectResult(item);
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
            return new CreatedAtRouteResult("GetQuestById",
                new { controller = "Quest", id = item.Id }, newQuest);
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
            var item = await _questItems.GetSingle(id);
            if (item == null)
            {
                return new NotFoundResult();
            }
            _questItems.Delete(item);
            await _questItems.Commit();
            return new OkResult();
        }
    }
}
