namespace APITecsup13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Details", "Igv", c => c.Double(nullable: false));
            AddColumn("dbo.Details", "Total", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Details", "Total");
            DropColumn("dbo.Details", "Igv");
        }
    }
}
