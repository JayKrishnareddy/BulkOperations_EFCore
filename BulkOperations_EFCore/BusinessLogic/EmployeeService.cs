using BulkOperations_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.BulkExtensions;

namespace BulkOperations_EFCore.BusinessLogic
{
    public class EmployeeService
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        #region Add Bulk Data
        public async Task<long> AddBulkDataAsync()
        {
            List<Employee> employees = new(); // C# Syntax
            for (int i = 1; i <= 100000; i++)
            {
                employees.Add(new Employee()
                {
                    Name = "Employee_" + i,
                    Designation = "Designation_" + i,
                    City = "City_" + i
                });
            }
            await _appDbContext.BulkInsertAsync(employees);
            return employees.Count;
        }
        #endregion

        #region Update Bulk Data
        public async Task<long> UpdateBulkDataAsync()
        {
            List<Employee> employees = new(); // C# Syntax
            for (int i = 0; i < 100000; i++)
            {
                employees.Add(new Employee()
                {
                    Id = i + 1,
                    Name = "UpdateEmployee_" + i,
                    Designation = "UpdateDesignation_" + i,
                    City = "UpdateCity_" + i
                });
            }
            await _appDbContext.BulkUpdateAsync(employees);
            return employees.Count;
        }
        #endregion

        #region Delete Bulk Data
        public async Task<bool> DeleteBulkDataAsync()
        {
            List<Employee> employees = new(); // C# Syntax
            employees = _appDbContext.Employees.ToList();
            await _appDbContext.BulkDeleteAsync(employees);
            return true;
        }
        #endregion
    }
}
