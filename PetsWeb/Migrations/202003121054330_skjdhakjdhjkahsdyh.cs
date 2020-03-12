namespace PetsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skjdhakjdhjkahsdyh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhysicalExaminations", "Ch24", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx24", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch25", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx25", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch26", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx26", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch27", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx27", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch28", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx28", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch29", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx29", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch30", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx30", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch31", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx31", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch32", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx32", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch33", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx33", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch34", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx34", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch35", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx35", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch36", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx36", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch37", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx37", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch38", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx38", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch39", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx39", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch40", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx40", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch41", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx41", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch42", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx42", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch43", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx43", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch44", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx44", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch45", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx45", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch46", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx46", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch47", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx47", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch48", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx48", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch49", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx49", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch50", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx50", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch51", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx51", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhysicalExaminations", "Tx51");
            DropColumn("dbo.PhysicalExaminations", "Ch51");
            DropColumn("dbo.PhysicalExaminations", "Tx50");
            DropColumn("dbo.PhysicalExaminations", "Ch50");
            DropColumn("dbo.PhysicalExaminations", "Tx49");
            DropColumn("dbo.PhysicalExaminations", "Ch49");
            DropColumn("dbo.PhysicalExaminations", "Tx48");
            DropColumn("dbo.PhysicalExaminations", "Ch48");
            DropColumn("dbo.PhysicalExaminations", "Tx47");
            DropColumn("dbo.PhysicalExaminations", "Ch47");
            DropColumn("dbo.PhysicalExaminations", "Tx46");
            DropColumn("dbo.PhysicalExaminations", "Ch46");
            DropColumn("dbo.PhysicalExaminations", "Tx45");
            DropColumn("dbo.PhysicalExaminations", "Ch45");
            DropColumn("dbo.PhysicalExaminations", "Tx44");
            DropColumn("dbo.PhysicalExaminations", "Ch44");
            DropColumn("dbo.PhysicalExaminations", "Tx43");
            DropColumn("dbo.PhysicalExaminations", "Ch43");
            DropColumn("dbo.PhysicalExaminations", "Tx42");
            DropColumn("dbo.PhysicalExaminations", "Ch42");
            DropColumn("dbo.PhysicalExaminations", "Tx41");
            DropColumn("dbo.PhysicalExaminations", "Ch41");
            DropColumn("dbo.PhysicalExaminations", "Tx40");
            DropColumn("dbo.PhysicalExaminations", "Ch40");
            DropColumn("dbo.PhysicalExaminations", "Tx39");
            DropColumn("dbo.PhysicalExaminations", "Ch39");
            DropColumn("dbo.PhysicalExaminations", "Tx38");
            DropColumn("dbo.PhysicalExaminations", "Ch38");
            DropColumn("dbo.PhysicalExaminations", "Tx37");
            DropColumn("dbo.PhysicalExaminations", "Ch37");
            DropColumn("dbo.PhysicalExaminations", "Tx36");
            DropColumn("dbo.PhysicalExaminations", "Ch36");
            DropColumn("dbo.PhysicalExaminations", "Tx35");
            DropColumn("dbo.PhysicalExaminations", "Ch35");
            DropColumn("dbo.PhysicalExaminations", "Tx34");
            DropColumn("dbo.PhysicalExaminations", "Ch34");
            DropColumn("dbo.PhysicalExaminations", "Tx33");
            DropColumn("dbo.PhysicalExaminations", "Ch33");
            DropColumn("dbo.PhysicalExaminations", "Tx32");
            DropColumn("dbo.PhysicalExaminations", "Ch32");
            DropColumn("dbo.PhysicalExaminations", "Tx31");
            DropColumn("dbo.PhysicalExaminations", "Ch31");
            DropColumn("dbo.PhysicalExaminations", "Tx30");
            DropColumn("dbo.PhysicalExaminations", "Ch30");
            DropColumn("dbo.PhysicalExaminations", "Tx29");
            DropColumn("dbo.PhysicalExaminations", "Ch29");
            DropColumn("dbo.PhysicalExaminations", "Tx28");
            DropColumn("dbo.PhysicalExaminations", "Ch28");
            DropColumn("dbo.PhysicalExaminations", "Tx27");
            DropColumn("dbo.PhysicalExaminations", "Ch27");
            DropColumn("dbo.PhysicalExaminations", "Tx26");
            DropColumn("dbo.PhysicalExaminations", "Ch26");
            DropColumn("dbo.PhysicalExaminations", "Tx25");
            DropColumn("dbo.PhysicalExaminations", "Ch25");
            DropColumn("dbo.PhysicalExaminations", "Tx24");
            DropColumn("dbo.PhysicalExaminations", "Ch24");
        }
    }
}
