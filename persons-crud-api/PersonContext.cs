using Microsoft.EntityFrameworkCore;
using persons_crud_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace persons_crud_api
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //postgresql standard name convention
            modelBuilder.ConvertToSnakeCase();
            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person() { 
                    Id = 1, 
                    Name = "Jimmy", 
                    LastName = "Raynor", 
                    Age = 42, 
                    Rut = 9810616, 
                    Vd = '2', 
                    Address = "Augustgrad 4112, Korhal" 
                },
                new Person() { 
                    Id = 2, 
                    Name = "Sarah", 
                    LastName = "Kerrigan", 
                    Age = 38, 
                    Rut = 11832947, 
                    Vd = '3', 
                    Address = "Talematros 243, Shakuras" 
                }
            );
        }
    }
}
