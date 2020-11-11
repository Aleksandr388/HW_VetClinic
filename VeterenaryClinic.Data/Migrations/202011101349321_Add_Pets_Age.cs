namespace VeterenaryClinic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Pets_Age : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pets", "Age");
        }
    }
}
