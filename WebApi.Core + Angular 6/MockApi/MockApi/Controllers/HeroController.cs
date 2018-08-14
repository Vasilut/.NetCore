using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MockApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Hero")]
    public class HeroController : Controller
    {
        private static List<Hero> _heroList = new List<Hero>()
        {
            new Hero(){ Id = 11, Name = "Mr Nice" },
            new Hero(){ Id = 12, Name = "Narco" },
            new Hero(){ Id = 13, Name = "Bombasto" },
            new Hero(){ Id = 14, Name = "Celeritas" },
            new Hero(){ Id = 15, Name = "Magneta" },
        };
        public HeroController()
        {

        }
        // GET: api/Hero
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Hero>))]
        public IEnumerable<Hero> Get()
        {
            return _heroList;
        }

        [HttpGet("search/{name?}")]
        [ProducesResponseType(200, Type = typeof(List<Hero>))]
        public IEnumerable<Hero> Search(string name)
        {
            var rezult = _heroList.Where(x => x.Name.Contains(name));
            if(rezult == null)
            {
            }
            return rezult.ToList();
        }


        // GET: api/Hero/heroes/5
        [HttpGet("heroes/{id}")]
        [ProducesResponseType(200, Type = typeof(Hero))]
        public JsonResult Get(int id)
        {
            return Json(_heroList.Where(x => x.Id == id).FirstOrDefault());
        }

        // POST: api/Hero
        [HttpPost("addHero")]
        [ProducesResponseType(200, Type = typeof(Hero))]
        public IActionResult Post([FromBody]Hero hero)
        {
            var index = _heroList.Last();
            hero.Id = index.Id + 1;
            _heroList.Add(hero);
            return Ok(hero);
        }

        [HttpPut("updateHero")]
        public IActionResult UpdateHero([FromBody] Hero hero)
        {
            return Put(hero.Id, hero);
        }


        // PUT: api/Hero/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Hero value)
        {
            foreach (var item in _heroList)
            {
                if(item.Id == id)
                {
                    item.Name = value.Name;
                    break;
                }
            }
            return NoContent();
        }


        [HttpDelete("deleteHero/{id}")]
        public IActionResult Delete(int id)
        {
            return Remove(id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var heroToDelete = _heroList.Where(hr => hr.Id == id).FirstOrDefault();
            if(heroToDelete == null)
            {
                return BadRequest($"The hero with id {id} does not exists");
            }
            _heroList.Remove(heroToDelete);
            return NoContent();
        }


    }
}
