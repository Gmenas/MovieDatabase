namespace MovieDatabase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
                        Title = c.String(nullable: false, maxLength: 50),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Title, unique: true);
            
            CreateTable(
                "dbo.MovieCastMembers",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false),
                        CastMember_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.CastMember_Id })
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.CastMembers", t => t.CastMember_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.CastMember_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieCastMembers", "CastMember_Id", "dbo.CastMembers");
            DropForeignKey("dbo.MovieCastMembers", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.MovieCastMembers", new[] { "CastMember_Id" });
            DropIndex("dbo.MovieCastMembers", new[] { "Movie_Id" });
            DropIndex("dbo.Movies", new[] { "Title" });
            DropTable("dbo.MovieCastMembers");
            DropTable("dbo.Movies");
            DropTable("dbo.CastMembers");
        }
    }
}
