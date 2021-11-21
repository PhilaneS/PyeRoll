using PagedList;
using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PayRoll.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Employee>> GetEmployees(int pageNumber, int pageSize)
        {
            return new PagedList<Employee>(await _dbContext.Employees.ToListAsync(), pageNumber, pageSize);
        }

        public async Task<IEnumerable<Employee>> GetSouthAfricanEmployees(int pageNumber, int pageSize, string CountryName)
        {
            var saEmployees = await _dbContext.Employees.Include(a => a.HomeAddress).Where(a => a.HomeAddress.Country == CountryName).ToListAsync();
            return new PagedList<Employee>(saEmployees, pageNumber, pageSize);
        }
       
    }
}