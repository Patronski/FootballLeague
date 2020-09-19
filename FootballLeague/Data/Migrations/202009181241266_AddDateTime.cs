namespace FootballLeague.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "DateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Teams", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teams", "Name", c => c.Int(nullable: false));
            DropColumn("dbo.Matches", "DateTime");
        }
    }
}
