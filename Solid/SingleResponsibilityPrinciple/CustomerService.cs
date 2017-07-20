using System;

namespace Solid.SingleResponsibilityPrinciple
{
  public class CustomerService
  {
    private readonly IRepository<Customer> customers;

    public CustomerService(IRepository<Customer> customers)
    {
      this.customers = customers;
    }

    public Customer UpdateCustomer(Customer customer)
    {
      if (String.IsNullOrEmpty(customer.Email)
      || String.IsNullOrEmpty(customer.Name))
      {
        throw new InvalidCustomerException();
      }

      var existingCustomer = customers.GetById(customer.ID);
      if (existingCustomer == null)
      {
        throw new CustomerNotFoundException();
      }

      var updatedCustomer = customers.Update(customer);

      return updatedCustomer;
    }

  }



  public class Customer
  {
    public long ID { get; }
    public string Name { get; }
    public string Email { get; }
  }

  public interface IRepository<T>
  {
    T Update(T obj);

    T GetById(long id);
  }

  public class InvalidCustomerException : Exception
  {
  }

  public class CustomerNotFoundException : Exception
  {
  }
}
