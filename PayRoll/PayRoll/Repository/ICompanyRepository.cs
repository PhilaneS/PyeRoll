using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PayRoll.Repository
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompanies(int pageNumber,int pageSize);
        Task<Company> GetCompanyById(int Id);

    }
}