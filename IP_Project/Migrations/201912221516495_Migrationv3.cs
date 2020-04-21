namespace IP_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrationv3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "date_id", "dbo.Dates");
            DropForeignKey("dbo.News", "date_id", "dbo.Dates");
            DropIndex("dbo.Events", new[] { "date_id" });
            DropIndex("dbo.News", new[] { "date_id" });
            AddColumn("dbo.Events", "date", c => c.DateTime(nullable: false));
            AddColumn("dbo.News", "date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Events", "date_id");
            DropColumn("dbo.News", "date_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "date_id", c => c.Int());
            AddColumn("dbo.Events", "date_id", c => c.Int());
            DropColumn("dbo.News", "date");
            DropColumn("dbo.Events", "date");
            CreateIndex("dbo.News", "date_id");
            CreateIndex("dbo.Events", "date_id");
            AddForeignKey("dbo.News", "date_id", "dbo.Dates", "id");
            AddForeignKey("dbo.Events", "date_id", "dbo.Dates", "id");
        }
    }
}
