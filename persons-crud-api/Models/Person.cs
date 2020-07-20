using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace persons_crud_api.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public int Rut { get; set; }
        public char Vd { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(60)]
        public string LastName { get; set; }
        public int Age { get; set; }

        [MaxLength(400)]
        public string Address { get; set; }
    }
}
