using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using persons_crud_api.Dtos;
using persons_crud_api.Extensions.Mappers;
using persons_crud_api.Models;

namespace persons_crud_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private static List<Person> Persons = new List<Person>()
        {
            new Person(){ Id=1, Name = "Jimmy", LastName = "Raynor", Age = 42, Rut = 9810616, Vd = '2', Address = "Augustgrad 4112, Korhal" },
            new Person(){ Id=2, Name = "Sarah", LastName = "Kerrigan", Age = 38, Rut = 11832947, Vd = '3', Address = "Talematros 243, Shakuras" }
        };

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PersonDto>> Get()
        {
            _logger.LogInformation("PersonController.Get");
            return Ok(Persons.Select(p => p.ToPersonDto()));
        }

        [HttpGet("/{id}")]
        public ActionResult<PersonDto> Get(int id)
        {
            _logger.LogInformation("PersonController.Get", id);
            Person person = Persons.FirstOrDefault(p => p.Id.Equals(id));
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person.ToPersonDto());
        }

        [HttpPost]
        public ActionResult<PersonDto> Post(NewPersonRequest newPersonRequest)
        {
            _logger.LogInformation("PersonController.Post", newPersonRequest);
            Person person = newPersonRequest.ToPerson();
            int id = Persons.Count() + 1 + 10000;
            person.Id = id;
            Persons.Add(person);
            return Ok(Persons.FirstOrDefault(p => p.Id.Equals(id)).ToPersonDto());
        }

        [HttpPut("/{id}")]
        public ActionResult<PersonDto> Put(int id, PersonDto personDto)
        {
            _logger.LogInformation("PersonController.Put", id, personDto);
            Person person = personDto.ToPerson();
            person.Id = id;

            int index = Persons.ToList().FindIndex(p => p.Id.Equals(id));

            Persons[index] = person;
            return Ok(Persons.ElementAt(index).ToPersonDto());
        }

        [HttpDelete("/{id}")]
        public ActionResult Delete(int id)
        {
            _logger.LogInformation("PersonController.Delete", id);
            try
            {
                int index = Persons.ToList().FindIndex(p => p.Id.Equals(id));
                Persons.RemoveAt(index);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "PersonController.Delete");
                return NotFound();
            }
        }

    }
}
