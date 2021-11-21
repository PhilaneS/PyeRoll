using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PayRoll.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees(int pageNumber, int pageSize);
        Task<IEnumerable<Employee>> GetSouthAfricanEmployees(int pageNumber, int pageSize, string CountryName);   
    }
}