namespace PetsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skjdhakjdhjkahsdyh555sddfk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhysicalExaminations", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhysicalExaminations", "Note");
        }
    }
}
