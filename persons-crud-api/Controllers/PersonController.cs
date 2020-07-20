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
        private readonly ILogger<PersonController> _logger;
        private readonly PersonContext _context;

        public PersonController(ILogger<PersonController> logger, PersonContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PersonDto>> Get()
        {
            _logger.LogInformation("PersonController.Get");
            return Ok(_context.Persons.OrderBy(p => p.Id).Select(p => p.ToPersonDto()));
        }

        [HttpGet("/{id}")]
        public ActionResult<PersonDto> Get(int id)
        {
            _logger.LogInformation("PersonController.Get", id);
            Person person = _context.Persons.FirstOrDefault(p => p.Id.Equals(id));
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
            person = _context.Persons.Add(person).Entity;
            _context.SaveChanges();
            return Ok(person.ToPersonDto());
        }

        [HttpPut("/{id}")]
        public ActionResult<PersonDto> Put(int id, PersonDto personDto)
        {
            _logger.LogInformation("PersonController.Put", id, personDto);
            Person person = personDto.ToPerson();
            person.Id = id;

            person = _context.Persons.Update(person).Entity;
            _context.SaveChanges();

            return Ok(person.ToPersonDto());
        }

        [HttpDelete("/{id}")]
        public ActionResult Delete(int id)
        {
            _logger.LogInformation("PersonController.Delete", id);
            try
            {
                Person person = _context.Persons.Find(id);
                _context.Persons.Remove(person);
                _context.SaveChanges();

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
