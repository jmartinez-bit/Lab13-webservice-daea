namespace APITecsup13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            AddColumn("dbo.Invoices", "CustomerID", c => c.Int());
            CreateIndex("dbo.Invoices", "CustomerID");
            AddForeignKey("dbo.Invoices", "CustomerID", "dbo.Customers", "CustomerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Invoices", new[] { "CustomerID" });
            DropColumn("dbo.Invoices", "CustomerID");
            DropTable("dbo.Customers");
        }
    }
}
