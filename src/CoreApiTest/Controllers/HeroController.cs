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

        [HttpGet]
        public IEnumerable<Hero> GetAll()
        {
            return new List<Hero>
            {
                new Hero
                {
                    Name = "Wolverine",
                    Id = 1,
                    IsRetired = false,
                }
            };
            //return _heroItems.GetAll();
        }

        //[HttpGet("{id}", Name = "GetTodo")]
        //public IActionResult GetById(int id)
        //{
        //    var item = _heroRepository.GetById(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return new ObjectResult(item);
        //}
    }
}
