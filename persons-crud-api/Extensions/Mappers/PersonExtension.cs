using persons_crud_api.Dtos;
using persons_crud_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace persons_crud_api.Extensions.Mappers
{
    public static class PersonExtension
    {
        public static PersonDto ToPersonDto (this Person person)
        {
            PersonDto dto = new PersonDto();
            dto.Name = person.Name;
            dto.LastName = person.LastName;
            dto.Age = person.Age;
            dto.Address = person.Address;
            dto.Vd = person.Vd;
            dto.Id = person.Id;
            dto.Rut = person.Rut;

            return dto;
        }
    }
}
