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
    [Route("api/Student")]
    public class StudentController: Controller
    {
        private SchoolContext _dbContext;

        public StudentController(SchoolContext db)
        {
            _dbContext = db;
        }

        [HttpGet]
        public IEnumerable<Student> Index()
        {
            return _dbContext.Student.ToList();
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var obj = _dbContext.Student.FirstOrDefault(p => p.Id == id);
            if (obj != null)
            {
                return JsonConvert.SerializeObject(obj);
            }
            return "Stud not found";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]Student student)
        {
            if (ModelState.IsValid)
            {
                int id = _dbContext.Profesor.Max(p => p.Id);
                Student stud = new Student { Age = student.Age, Name = student.Name, Id = id };
                _dbContext.Student.Add(stud);
                int nr = _dbContext.SaveChanges();
                return "Stud inserted";
            }
            return "Model is not valid";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var obj = _dbContext.Student.FirstOrDefault(p => p.Id == id);
            if (obj != null)
            {
                _dbContext.Student.Remove(obj);
                _dbContext.SaveChanges();
                return "Object Deleted";
            }
            return "Stud not found";
        }

    }
}
