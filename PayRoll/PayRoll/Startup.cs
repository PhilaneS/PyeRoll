using System;
using System.Linq;
using Microsoft.Owin;
using Owin;
using PayRoll.Models;

[assembly: OwinStartupAttribute(typeof(PayRoll.Startup))]
namespace PayRoll
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            SeedWithTestData();
        }

        private void SeedWithTestData()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            //there is no companies, so it must mean there is no data
            //Seed with test data.
            if (db.Companies.Count() == 0)
            {
                CreateAcmeCompany(db);
                CreateBigBoxCorpCompany(db);
                CreateElboniaCompany(db);
                db.SaveChanges();
            }
        }

        private void CreateAcmeCompany(ApplicationDbContext db)
        {
            Address Addr1 = new Address()
            {
                Country = "South Africa",
                City = "Johannesburg",
                Street = "1 Red street"
            };
            Employee emp1 = new Employee()
            {
                FirstName = "Adam",
                LastName = "Johnson",
                Position = "Clerk",
                HomeAddress = Addr1
            };

            Address Addr2 = new Address()
            {
                Country = "South Africa",
                City = "Johannesburg",
                Street = "2 Blue street"
            };
            Employee emp2 = new Employee()
            {
                FirstName = "Bob",
                LastName = "Paulson",
                Position = "Clerk",
                HomeAddress = Addr2
            };

            Address Addr3 = new Address()
            {
                Country = "South Africa",
                City = "Johannesburg",
                Street = "3 Green Street"
            };
            Employee emp3 = new Employee()
            {
                FirstName = "Charlie",
                LastName = "Peterson",
                Position = "Manager",
                HomeAddress = Addr3
            };

            Address Addr4 = new Address()
            {
                Country = "South Africa",
                City = "Pretoria",
                Street = "4 Purple Street"
            };
            Employee emp4 = new Employee()
            {
                FirstName = "Dean",
                LastName = "Ericson",
                Position = "Owner",
                HomeAddress = Addr4
            };

            Address Addr = new Address()
            {
                Country = "South Africa",
                City = "Johannesburg",
                Street = "5 Orange Street"
            };
            Company comp = new Company()
            {
                Name = "ACME",
                BusinessAddress = Addr
            };
            comp.Employees.Add(emp1);
            comp.Employees.Add(emp2);
            comp.Employees.Add(emp3);
            comp.Employees.Add(emp4);

            db.Companies.Add(comp);
        }

        private void CreateBigBoxCorpCompany(ApplicationDbContext db)
        {
            Address Addr1 = new Address()
            {
                Country = "South Africa",
                City = "Johannesburg",
                Street = "7 Lime Street"
            };
            Employee emp1 = new Employee()
            {
                FirstName = "Eric",
                LastName = "Frankenstein",
                Position = "Clerk",
                HomeAddress = Addr1
            };

            Address Addr2 = new Address()
            {
                Country = "South Africa",
                City = "Sandton",
                Street = "8 Majenta Street"
            };
            Employee emp2 = new Employee()
            {
                FirstName = "Frank",
                LastName = "Hyde",
                Position = "Clerk",
                HomeAddress = Addr2
            };

            Address Addr3 = new Address()
            {
                Country = "South Africa",
                City = "Centurion",
                Street = "9 Cyan Street"
            };
            Employee emp3 = new Employee()
            {
                FirstName = "Garret",
                LastName = "Jackel",
                Position = "Manager",
                HomeAddress = Addr3
            };

            Address Addr4 = new Address()
            {
                Country = "South Africa",
                City = "Pretoria",
                Street = "10 Yellow Street"
            };
            Employee emp4 = new Employee()
            {
                FirstName = "Henry",
                LastName = "Lechter",
                Position = "Owner",
                HomeAddress = Addr4
            };

            Address Addr = new Address()
            {
                Country = "South Africa",
                City = "Midrand",
                Street = "11 White Street"
            };
            Company comp = new Company()
            {
                Name = "Big Box Corp.",
                BusinessAddress = Addr
            };
            comp.Employees.Add(emp1);
            comp.Employees.Add(emp2);
            comp.Employees.Add(emp3);
            comp.Employees.Add(emp4);

            db.Companies.Add(comp);
        }

        private void CreateElboniaCompany(ApplicationDbContext db)
        {
            Address Addr1 = new Address()
            {
                Country = "Bulgaria",
                City = "Sofia",
                Street = "12 Black Street"
            };
            Employee emp1 = new Employee()
            {
                FirstName = "Ivan",
                LastName = "Debrovnik",
                Position = "Clerk",
                HomeAddress = Addr1
            };

            Address Addr2 = new Address()
            {
                Country = "Bulgaria",
                City = "Sofia",
                Street = "13 Gray Street"
            };
            Employee emp2 = new Employee()
            {
                FirstName = "Jacob",
                LastName = "Kalashnikov",
                Position = "Clerk",
                HomeAddress = Addr2
            };

            Address Addr3 = new Address()
            {
                Country = "Bulgaria",
                City = "Plovdiv",
                Street = "14 Navy Street"
            };
            Employee emp3 = new Employee()
            {
                FirstName = "Kevin",
                LastName = "Putin",
                Position = "Manager",
                HomeAddress = Addr3
            };

            Address Addr4 = new Address()
            {
                Country = "Bulgaria",
                City = "Shumen",
                Street = "15 Maroon Street"
            };
            Employee emp4 = new Employee()
            {
                FirstName = "Lance",
                LastName = "Abramov",
                Position = "Owner",
                HomeAddress = Addr4
            };

            Address Addr = new Address()
            {
                Country = "Bulgaria",
                City = "Plovdiv",
                Street = "16 Aqua Street"
            };
            Company comp = new Company()
            {
                Name = "Elbonia",
                BusinessAddress = Addr
            };
            comp.Employees.Add(emp1);
            comp.Employees.Add(emp2);
            comp.Employees.Add(emp3);
            comp.Employees.Add(emp4);

            db.Companies.Add(comp);
        }
    }
}
