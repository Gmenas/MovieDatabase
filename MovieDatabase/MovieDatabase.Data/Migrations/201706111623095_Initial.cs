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
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Year = c.Int(nullable: false),
                        Director_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CastMembers", t => t.Director_Id)
                .Index(t => t.Director_Id);
            
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
            DropForeignKey("dbo.MoviesActors", "Actor_Id", "dbo.CastMembers");
            DropForeignKey("dbo.MoviesActors", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.MoviesActors", new[] { "Actor_Id" });
            DropIndex("dbo.MoviesActors", new[] { "Movie_Id" });
            DropIndex("dbo.Movies", new[] { "Director_Id" });
            DropTable("dbo.MoviesActors");
            DropTable("dbo.Movies");
            DropTable("dbo.CastMembers");
        }
    }
}
