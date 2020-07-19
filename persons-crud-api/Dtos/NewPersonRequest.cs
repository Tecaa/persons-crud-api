﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace persons_crud_api.Dtos
{
    public class NewPersonRequest
    {
        public int Rut { get; set; }
        public char Vc { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
