using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CoreApiTest.Models.Quest;

namespace CoreApiTest.Controllers
{
    [Route("api/[controller]")]
    public class QuestController : Controller
    {

        public QuestController(IQuestRepository QuestItems)
        {
            _QuestItems = QuestItems;
        }
        private IQuestRepository _QuestItems { get; set; }

        // GET api/<controller>
        [HttpGet(Name = "GetAllQuestes")]
        public async Task<IEnumerable<Quest>> GetAll()
        {
            return await _QuestItems.GetAll();
        }

        // GET api/<controller>/{id}
        [HttpGet("{id}", Name = "GetQuestById")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _QuestItems.GetById(id);
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
            await _QuestItems.Add(item);
            //return CreatedAtRoute("GetQuestById", new { id = item.IdQuest });
            return CreatedAtRoute("GetQuestById", new { id = item.IdQuest }, item);
        }

        // PUT api/<controller>
        [HttpPut("{id}", Name = "UpdateQuest")]
        public async Task<IActionResult> Update(int id, [FromBody] Quest item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var Quest = await _QuestItems.GetById(id);
            if (Quest == null)
            {
                return NotFound();
            }
            Quest.Title = item.Title;
            Quest.IsCompleted = item.IsCompleted;
            Quest.IdHero = item.IdHero;

            await _QuestItems.Update(Quest);
            return Ok();
        }

        // DELETE api/<controller>/{id}
        [HttpDelete("{id}", Name = "DeleteQuest")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _QuestItems.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            await _QuestItems.Delete(item);
            return Ok();
        }
    }
}
