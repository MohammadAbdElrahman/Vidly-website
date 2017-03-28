namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameMembershipTypePropety : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "MempershipTypeId", newName: "MembershipTypeId");
            RenameIndex(table: "dbo.Customers", name: "IX_MempershipTypeId", newName: "IX_MembershipTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Customers", name: "IX_MembershipTypeId", newName: "IX_MempershipTypeId");
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "MempershipTypeId");
        }
    }
}
