using System;

namespace Solid.CleanCode
{
  public class Calculator
  {
    public int Add(int a, int b)
    {
      return a + b;
    }

    public bool SavePerson(Person person)
    {
      return false;
    }

    public class Person
    {
      String firstName;
      String lastName;
      String city;
      String state;
    }
  }
}