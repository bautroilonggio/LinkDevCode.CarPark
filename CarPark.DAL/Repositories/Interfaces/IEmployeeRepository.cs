﻿using CarPark.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DAL.Repositories
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<(IEnumerable<Employee>, PaginationMetadata)> GetAllAsync(string? employeeName, string? searchQuery, int pageNumber, int pageSize);
    }
}
