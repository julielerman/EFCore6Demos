using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;



namespace EFCore6Demos
{
  partial class Program
  {
    static PeopleContext _context;
    static void Main(string[] args)
    {
      _context = new PeopleContext();
      _context.Database.EnsureDeleted();
      _context.Database.EnsureCreated();
      InsertAddress();
      ReadAddresswithValueconverters();
    }

    private static void InsertAddress()
    {
      var add1 = new Address {City="Vilnius", Street = "Gediminas Avenue",
         BuildingColor = System.Drawing.Color.Blue,
          AddressTypeEnum = AddressTypeEnum.Home };
      _context.Set<Address>().Add(add1);
      _context.SaveChanges();
    }

     
    private static void ReadAddresswithValueconverters()
    {
      var addresses = _context.Set<Address>().ToList();
    }
   
  }
}
