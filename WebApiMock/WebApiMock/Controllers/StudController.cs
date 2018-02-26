using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApiMock.Controllers
{
    [Route("api/Stud")]
    public class StudController : Controller
    {
        private SchoolContext _dbContext;

        public StudController(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET api/values
        [HttpGet("/students")]
        public IEnumerable<Student> Index()
        {
            var entities = _dbContext.Student.ToList();
            return entities;
        }
        

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
