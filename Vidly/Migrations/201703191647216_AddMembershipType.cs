namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MempershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "MempershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MempershipTypeId");
            AddForeignKey("dbo.Customers", "MempershipTypeId", "dbo.MempershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MempershipTypeId", "dbo.MempershipTypes");
            DropIndex("dbo.Customers", new[] { "MempershipTypeId" });
            DropColumn("dbo.Customers", "MempershipTypeId");
            DropTable("dbo.MempershipTypes");
        }
    }
}
