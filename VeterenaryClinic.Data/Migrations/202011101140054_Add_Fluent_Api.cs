namespace VeterenaryClinic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Fluent_Api : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Communications", "Phone", c => c.String(maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Communications", "Phone", c => c.String());
        }
    }
}
