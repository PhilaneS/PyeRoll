namespace PayRoll.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Text;

    public partial class CreateGetEmployeeByCountryNameStoredProcedure : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
             "GetEmployeesByCountryName",
             p => new
             {
                 CountryName = p.String(200)
             },
             @"SELECT 
               e.ID,
					e.FirstName,
    		        e.LastName,    		       
					e.Position,
					 a.Country
	        FROM Employees e
		        INNER JOIN Addresses a ON a.ID = e.HomeAddressID 
	        WHERE Country = @CountryName"
           );
        }

        public override void Down()
        {
            DropStoredProcedure("GetEmployeesByCountryName");
        }
    }
}
