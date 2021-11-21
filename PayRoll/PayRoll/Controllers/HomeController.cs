using log4net;
using PayRoll.Filters;
using PayRoll.Helper;
using PayRoll.Models;
//using PayRoll.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    [PayRollAuthorization]
    public class HomeController : Controller
    {
        private readonly Repository.ICompanyRepository _company;
        private readonly Repository.IEmployeeRepository _employee;
        private readonly ILog _log;

        public HomeController(Repository.ICompanyRepository company, Repository.IEmployeeRepository employee, ILog log)
        {
            _company = company;
            _employee = employee;
            _log = log;
        }

        public ActionResult Index()
        {
            _log.Info("lo4net OK");
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> ListAllCompanies(int page = 1)
        {
            try
            {
                _log.Info("Caling GetAllCompanies");

                var companies = await _company.GetAllCompanies(page, 10);

                _log.Info("GetAllCompanies excecuted successfully");

                return View(companies);

            }
            catch (Exception e)
            {
                _log.Info("ListAllCompanies Call failed");
                _log.Error(e);
                return View();
            }

        }

        public async Task<ActionResult> CompanyDetails(int? id)
        {
            _log.Info("Calling CompanyDetails function");

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var company = await _company.GetCompanyById((int)id);

                if (company == null)
                {
                    return HttpNotFound();
                }
                _log.Info("CompanyDetails executed successfully");

                return View(company);
            }
            catch (Exception e)
            {

                _log.Info("CompanyDetails Call failed");
                _log.Error(e);
                return View();
            }

            
        }

        [HttpGet]
        public async Task<ActionResult> ListAllEmployees(int page = 1, int pageSize = 10)
        {
            _log.Info("Calling ListAllEmployees function");

            try
            {
                var employees = await _employee.GetEmployees(page, pageSize);
                _log.Info("ListAllEmployees executed successfully");

                return View(employees);
            }
            catch (Exception e)
            {

                _log.Info("ListAllEmployees Call failed");
                _log.Error(e);
                return View();

            }

        }

        [HttpGet]
        public async Task<ActionResult> ListSouthAfricanEmployees(int page = 1, int pageSize = 10)
        {
            _log.Info("Calling ListSouthAfricanEmployees function");

            try
            {
                var countryDetails = await _employee.GetSouthAfricanEmployees(page, pageSize, Constants.SouthAfrica);

                if (!countryDetails.Any())
                    return HttpNotFound();

                _log.Info("ListSouthAfricanEmployees executed successfully");

                return View(countryDetails);

            }
            catch (Exception e)
            {
                _log.Info("ListAllEmployees Call failed");
                _log.Error(e);
                return View();

            }
        }
    }
}