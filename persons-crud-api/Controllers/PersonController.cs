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
        public IEnumerable<PersonDto> Get()
        {
            _logger.LogInformation("PersonController.Get");
            return Persons.Select(p => p.ToPersonDto());
        }

        [HttpGet("/{id}")]
        public PersonDto Get(int id)
        {
            _logger.LogInformation("PersonController.Get", id);
            return Persons.FirstOrDefault(p => p.Id.Equals(id)).ToPersonDto();
        }

        [HttpPost]
        public PersonDto Post(NewPersonRequest newPersonRequest)
        {
            _logger.LogInformation("PersonController.Post", newPersonRequest);
            Person person = newPersonRequest.ToPerson();
            int id = Persons.Count() + 1 + 10000;
            person.Id = id;
            Persons.Add(person);
            return Persons.FirstOrDefault(p => p.Id.Equals(id)).ToPersonDto();
        }

        [HttpPut("/{id}")]
        public PersonDto Put(int id, PersonDto personDto)
        {
            _logger.LogInformation("PersonController.Put", personDto);
            Person person = personDto.ToPerson();
            person.Id = id;

            int index = Persons.ToList().FindIndex(p => p.Id.Equals(id));

            Persons[index] = person;
            return Persons.ElementAt(index).ToPersonDto();
        }


    }
}
