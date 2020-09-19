namespace FootballLeague.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedgoals : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "LeftTeamGoals", c => c.Int());
            AddColumn("dbo.Matches", "RightTeamGoals", c => c.Int());
            AlterColumn("dbo.Teams", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teams", "Name", c => c.String());
            DropColumn("dbo.Matches", "RightTeamGoals");
            DropColumn("dbo.Matches", "LeftTeamGoals");
        }
    }
}
