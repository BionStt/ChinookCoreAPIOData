﻿using System;
using System.Collections.Generic;
using ChinookCoreAPIOData.Domain.Entities;

namespace ChinookCoreAPIOData.Domain.Repositories
{
    public interface IEmployeeRepository : IDisposable
    {
        List<Employee> GetAll();
        Employee GetById(int id);
        Employee GetReportsTo(int id);
        Employee Add(Employee newEmployee);
        bool Update(Employee employee);
        bool Delete(int id);
        List<Employee> GetDirectReports(int id);
    }
}