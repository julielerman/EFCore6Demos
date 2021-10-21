using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCore6Demos
{
  class Program
  {
    static PeopleContext _context;
    static void Main(string[] args)
    {
      _context = new PeopleContext();
        _context.Database.EnsureDeleted();
         _context.Database.EnsureCreated();
      SeedSomeData();
      //TemporalQuery();
    }

    private static void TemporalQuery()
    {
      var resultTypical = _context.People.ToList();
      DateTime auditDate = DateTime.Parse("2021-10-21 12:51:50");
      var resultTemporal = _context.People.TemporalAsOf(auditDate).ToList();
    }

    private static void SeedSomeData()
    {
      var p1 = new Person { FirstName = "John", LastName = "Smith" };
      var p2 = new Person { FirstName = "Andriy", LastName = "Svyryd" };
      var p3 = new Person { FirstName = "George", LastName = "Jetson" };
      _context.People.AddRange(p1, p2, p3);
      _context.SaveChanges();
    }
  }
}
