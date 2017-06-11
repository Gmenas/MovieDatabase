namespace MovieDatabase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Title, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Movies", new[] { "Title" });
            DropTable("dbo.Movies");
        }
    }
}
