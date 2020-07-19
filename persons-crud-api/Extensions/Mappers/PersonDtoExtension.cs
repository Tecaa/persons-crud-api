using persons_crud_api.Dtos;
using persons_crud_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace persons_crud_api.Extensions.Mappers
{
    public static class PersonDtoExtension
    {
        public static Person ToPerson (this PersonDto dto)
        {
            Person person = new Person();
            person.Name = dto.Name;
            person.LastName = dto.LastName;
            person.Age = dto.Age;
            person.Address = dto.Address;
            person.Vd = dto.Vd;
            person.Id = dto.Id;
            person.Rut = dto.Rut;

            return person;
        }
    }
}
