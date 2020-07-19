using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace persons_crud_api.Models
{
    public class Person
    {
        public int Id { get; set; }
        public int Rut { get; set; }
        public char Vd { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
