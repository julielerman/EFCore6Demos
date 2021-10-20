using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmosProviderSample {
  class Program {
   
    static void Main (string[] args) {
      AddPerson();
    }

    private static void AddPerson()
    {
      using var context=new PeopleContext();
      context.People.Add(new Person("Julie","Lerman"));
      context.SaveChanges();
    }
  }
}