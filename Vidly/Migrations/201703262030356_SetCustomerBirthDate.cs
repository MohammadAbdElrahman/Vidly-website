namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetCustomerBirthDate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate ='1-1-1990' WHERE Id = 2");

        }
        
        public override void Down()
        {
        }
    }
}
