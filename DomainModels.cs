using System;
using System.Collections.Generic;


public class Person
{
    private  Person()
    {
        
    }
    public Person(string firstName,string lastName)
    {
        Addresses = new List<Address>();
        Id=Guid.NewGuid();
        FirstName=firstName;
        LastName=lastName;
    }
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
   public string FullName => $"{FirstName.Trim()} {LastName.Trim()}";
    public List<Address> Addresses { get; set; }
}
public class Address
{
    public Guid Id { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public AddressType AddressType { get; set; }
    public Guid PersonId { get; set; }
}

public enum AddressType
{
    Home = 1,
    Work = 2

}
