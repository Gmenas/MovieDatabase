namespace MovieDatabase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CastMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Year = c.Int(nullable: false),
                        Country_Id = c.Int(),
                        Director_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.CastMembers", t => t.Director_Id)
                .Index(t => t.Title, unique: true)
                .Index(t => t.Country_Id)
                .Index(t => t.Director_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MoviesActors",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false),
                        Actor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.Actor_Id })
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.CastMembers", t => t.Actor_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.Actor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Director_Id", "dbo.CastMembers");
            DropForeignKey("dbo.Movies", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.MoviesActors", "Actor_Id", "dbo.CastMembers");
            DropForeignKey("dbo.MoviesActors", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.MoviesActors", new[] { "Actor_Id" });
            DropIndex("dbo.MoviesActors", new[] { "Movie_Id" });
            DropIndex("dbo.Movies", new[] { "Director_Id" });
            DropIndex("dbo.Movies", new[] { "Country_Id" });
            DropIndex("dbo.Movies", new[] { "Title" });
            DropIndex("dbo.CastMembers", new[] { "Name" });
            DropTable("dbo.MoviesActors");
            DropTable("dbo.Countries");
            DropTable("dbo.Movies");
            DropTable("dbo.CastMembers");
        }
    }
}
