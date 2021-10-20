using System;
using System.Collections.Generic;
using System.Linq;

namespace CompiledModelDemo
{
    class Program
    {
        static PeopleContext _context;
        static void Main(string[] args)
        {
            _context = new PeopleContext();
            _context.Database.EnsureDeleted();
             _context.Database.EnsureCreated();
             RelatedInsert();
 
           
        }
      
        private static void RelatedInsert()
        {
            var person = new Person { Id = Guid.NewGuid(), FirstName = "Shay", LastName = "Rojansky" };
            person.Addresses.Add(new Address { Id = Guid.NewGuid(), AddressType = AddressType.Work, Street = "Two Main", PostalCode = "12345" });
             
            _context.People.Add(person);
            _context.SaveChanges();
        }
      
    }
}
