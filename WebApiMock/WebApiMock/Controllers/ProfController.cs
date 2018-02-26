using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMock.Controllers
{

    [Route("api/Prof")]
    public class ProfController: Controller
    {
        private SchoolContext _dbContext;

        public ProfController(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Profesor> Index()
        {
            return _dbContext.Profesor.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var obj = _dbContext.Profesor.FirstOrDefault(p => p.Id == id);
            if (obj != null)
            {
                return JsonConvert.SerializeObject(obj);
            }
            return "Prof not found";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]Profesor prof)
        {
            if (ModelState.IsValid)
            {
                int id = _dbContext.Profesor.Max(p => p.Id);
                Profesor pro = new Profesor { Disciplina = prof.Disciplina, Name = prof.Name, Id = id };
                _dbContext.Profesor.Add(pro);
                int nr = _dbContext.SaveChanges();
                return "Prof inserted";
            }
            return "Model is not valid";
        }
        

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var obj = _dbContext.Profesor.FirstOrDefault(p => p.Id == id);
            if(obj!= null)
            {
                _dbContext.Profesor.Remove(obj);
                _dbContext.SaveChanges();
                return "Object Deleted";
            }
            return "Prof not found";
        }
    }
}
