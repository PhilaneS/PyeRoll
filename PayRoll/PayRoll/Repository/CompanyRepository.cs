using PagedList;
using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PayRoll.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CompanyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Models.Company>> GetAllCompanies(int pageNumber,int pageSize)
        {
            var companies = await _dbContext.Companies.ToListAsync();            
            return new PagedList<Models.Company>(companies, pageNumber, pageSize);
        }

        public async Task<Models.Company> GetCompanyById(int Id)
        {
            return await _dbContext.Companies.FirstOrDefaultAsync(x=> x.ID == Id);
        }
    }
}