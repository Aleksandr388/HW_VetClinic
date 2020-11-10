namespace VeterenaryClinic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Communications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VetClinics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        FullNameOwner = c.String(),
                        TypeTreatment = c.String(),
                        PetId = c.Int(nullable: false),
                        CommunicationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Communications", t => t.CommunicationId, cascadeDelete: true)
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .Index(t => t.PetId)
                .Index(t => t.CommunicationId);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PetName = c.String(),
                        PetBreed = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VetClinics", "PetId", "dbo.Pets");
            DropForeignKey("dbo.VetClinics", "CommunicationId", "dbo.Communications");
            DropIndex("dbo.VetClinics", new[] { "CommunicationId" });
            DropIndex("dbo.VetClinics", new[] { "PetId" });
            DropTable("dbo.Pets");
            DropTable("dbo.VetClinics");
            DropTable("dbo.Communications");
        }
    }
}
