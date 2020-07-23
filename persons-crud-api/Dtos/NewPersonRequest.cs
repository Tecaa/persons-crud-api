using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace persons_crud_api.Dtos
{
    public class NewPersonRequest
    {
        [Required]
        public int Rut { get; set; }
        [Required]
        public char Vd { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(60)]
        public string LastName { get; set; }
        [Range(19, int.MaxValue)]
        public int? Age { get; set; }
        [MaxLength(400)]
        public string Address { get; set; }
    }
}
