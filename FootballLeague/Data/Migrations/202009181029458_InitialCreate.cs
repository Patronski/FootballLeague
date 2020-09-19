namespace FootballLeague.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeftTeam_Id = c.Int(),
                        RightTeam_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.LeftTeam_Id)
                .ForeignKey("dbo.Teams", t => t.RightTeam_Id)
                .Index(t => t.LeftTeam_Id)
                .Index(t => t.RightTeam_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "RightTeam_Id", "dbo.Teams");
            DropForeignKey("dbo.Matches", "LeftTeam_Id", "dbo.Teams");
            DropIndex("dbo.Matches", new[] { "RightTeam_Id" });
            DropIndex("dbo.Matches", new[] { "LeftTeam_Id" });
            DropTable("dbo.Teams");
            DropTable("dbo.Matches");
        }
    }
}
