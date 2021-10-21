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
      InsertCyrillicAddress();
      ReadAddresswithValueconverters();
    }

    private static void InsertAddress()
    {
      var add1 = new Address {City="北京", Street = "1 Main", BuildingColor = System.Drawing.Color.Blue, AddressTypeEnum = AddressTypeEnum.Home };
      _context.Set<Address>().Add(add1);
      _context.SaveChanges();
    }

    private static void InsertCyrillicAddress()
    {
      var martaStreet = new Address { Street = "Улица 8 марта", AddressTypeEnum = AddressTypeEnum.Home };
      _context.Set<Address>().Add(martaStreet);
      _context.SaveChanges();
    }

    
    private static void ReadAddresswithValueconverters()
    {
      var addresses = _context.Set<Address>().ToList();
    }
   
  }
}
