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
            return await _questItems.GetAll();
        }

        // GET api/<controller>/{id}
        [HttpGet("{id}", Name = "GetQuestById")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _questItems.GetSingle(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/<controller>
        [HttpPost(Name = "CreateQuest")]
        public async Task<IActionResult> Create([FromBody] Quest item)
        {
            if (item == null)
            {
                return BadRequest();
            }
             _questItems.Add(item);
            await _questItems.Commit();
            return CreatedAtRoute("GetQuestById",
                new { controller = "Quest", id = item.Id }, item);
        }

        // PUT api/<controller>
        [HttpPut("{id}", Name = "UpdateQuest")]
        public async Task<IActionResult> Update(int id, [FromBody] Quest item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var quest = await _questItems.GetSingle(id);
            if (quest == null)
            {
                return NotFound();
            }
            quest.Title = item.Title;
            quest.IsCompleted = item.IsCompleted;
            quest.IdHero = item.IdHero;

            _questItems.Update(quest);
            await _questItems.Commit();
            return Ok();
        }

        // DELETE api/<controller>/{id}
        [HttpDelete("{id}", Name = "DeleteQuest")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _questItems.GetSingle(id);
            if (item == null)
            {
                return NotFound();
            }
            _questItems.Delete(item);
            await _questItems.Commit();
            return Ok();
        }
    }
}
