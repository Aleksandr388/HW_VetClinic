namespace VeterenaryClinic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Price_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PriceValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.VetClinics", "PriceId", c => c.Int(nullable: false));
            CreateIndex("dbo.VetClinics", "PriceId");
            AddForeignKey("dbo.VetClinics", "PriceId", "dbo.Prices", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VetClinics", "PriceId", "dbo.Prices");
            DropIndex("dbo.VetClinics", new[] { "PriceId" });
            DropColumn("dbo.VetClinics", "PriceId");
            DropTable("dbo.Prices");
        }
    }
}
