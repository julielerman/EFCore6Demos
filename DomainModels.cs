using System;
using System.Collections.Generic;


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
    public string PostalCode { get; set; }
    public AddressType AddressType { get; set; }
    public Guid PersonId { get; set; }
    public string StreetLine2 { get; set; }
}

public enum AddressType
{
    Home = 1,
    Work = 2

}
