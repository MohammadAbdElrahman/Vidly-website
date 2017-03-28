namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoviesData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded,ReleaseDate,NumberInStock)" +
                "VALUES ('Hangover', 5,'2005-1-5','2000-1-5', 0)");
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded,ReleaseDate,NumberInStock)" +
                "VALUES ('Die Hard', 1,'2010-1-5','2002-1-5', 3)");
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded,ReleaseDate,NumberInStock)" +
                "VALUES ('The Terminator', 1,'2003-1-5','2001-1-5', 1)");
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded,ReleaseDate,NumberInStock)" +
                "VALUES ('Toy Story', 3,'2010-5-4','2005-6-9', 2)");
        }
        
        public override void Down()
        {
        }
    }
}
