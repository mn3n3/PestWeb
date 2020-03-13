namespace PetsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MohammedAwad120320204 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PhysicalExaminations", "Note");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhysicalExaminations", "Note", c => c.String());
        }
    }
}
