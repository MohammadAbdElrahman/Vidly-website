namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AplyAnnotationsToCustomerName : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.MempershipTypes", newName: "MembershipTypes");
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String());
            RenameTable(name: "dbo.MembershipTypes", newName: "MempershipTypes");
        }
    }
}
