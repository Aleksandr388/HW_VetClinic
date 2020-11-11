namespace VeterenaryClinic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Prices", "PriceValue", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Prices", "PriceValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
