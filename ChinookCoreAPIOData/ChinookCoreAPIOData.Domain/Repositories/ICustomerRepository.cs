using System;
using System.Collections.Generic;
using ChinookCoreAPIOData.Domain.Entities;

namespace ChinookCoreAPIOData.Domain.Repositories
{
    public interface ICustomerRepository : IDisposable
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        List<Customer> GetBySupportRepId(int id);
        Customer Add(Customer newCustomer);
        bool Update(Customer customer);
        bool Delete(int id);
    }
}