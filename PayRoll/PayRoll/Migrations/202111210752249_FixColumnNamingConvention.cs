namespace PayRoll.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixColumnNamingConvention : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "FirstName", c => c.String());
            DropColumn("dbo.Employees", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Name", c => c.String());
            DropColumn("dbo.Employees", "FirstName");
        }
    }
}
