using persons_crud_api.Dtos;
using persons_crud_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace persons_crud_api.Extensions.Mappers
{
    public static class NewPersonRequestExtension
    {
        public static Person ToPerson (this NewPersonRequest newPersonRequest)
        {
            Person person = new Person();
            person.Name = newPersonRequest.Name;
            person.LastName = newPersonRequest.LastName;
            person.Age = newPersonRequest.Age;
            person.Address = newPersonRequest.Address;
            person.Vd = newPersonRequest.Vd;
            person.Rut = newPersonRequest.Rut;

            return person;
        }
    }
}
