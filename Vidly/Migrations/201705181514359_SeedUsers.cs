namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1a89c8bf-e786-4f6b-80d6-379a582c9d5f', N'admin@vidly.com', 0, N'AFoHeM+wT9W2u6IJoSvdQYxqbO6jFL6+SJ4dXxLZ2xKzK7EXLFfWdhc9dNA8McdlgA==', N'77d0b2dc-c527-4b0b-b69a-9dbc92389864', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e20d56e8-993f-409e-901f-edf3172f3e89', N'muhamad.abdalrahman@gmail.com', 0, N'ANsJXeAMraRGuVI4/5pHI2ArHvYmYcsbZ83QyQNQdKitjYKZNrqPuiKMOyOdgrx1Qg==', N'13327d86-c9b2-4717-827d-4d48af5bdb79', NULL, 0, 0, NULL, 1, 0, N'muhamad.abdalrahman@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c57f148a-7197-45d6-8d05-a0771a9d471c', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1a89c8bf-e786-4f6b-80d6-379a582c9d5f', N'c57f148a-7197-45d6-8d05-a0771a9d471c')

");
        }
        
        public override void Down()
        {
        }
    }
}
