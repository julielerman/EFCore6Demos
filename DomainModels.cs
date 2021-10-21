using System;
using System.Collections.Generic;
using System.Drawing;

public class Person
{
  public Person()
  {
    Addresses = new List<Address>();
  }
  public Guid Id { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public List<Address> Addresses { get; set; }
}

public class Address
{
  public Guid Id { get; set; }
  public string Street { get; set; }
  public string City { get; set; }
  public string PostalCode { get; set; }
  public AddressTypeEnum AddressTypeEnum { get; set; }
  public string StreetLine2 { get; set; }
  public Color BuildingColor { get; set; }
}

public enum AddressTypeEnum
{
  Home = 1,
  Work = 2
}
