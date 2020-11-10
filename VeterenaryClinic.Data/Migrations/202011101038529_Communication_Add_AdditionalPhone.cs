namespace VeterenaryClinic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Communication_Add_AdditionalPhone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Communications", "AdditionalPhone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Communications", "AdditionalPhone");
        }
    }
}
