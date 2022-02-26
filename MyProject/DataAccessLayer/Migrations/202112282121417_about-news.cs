namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aboutnews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "WhoAreWeText", c => c.String());
            AddColumn("dbo.Abouts", "WhatDoWeDo", c => c.String());
            AddColumn("dbo.Abouts", "AboutUsInFooter", c => c.String());
            DropColumn("dbo.Abouts", "AboutContent1");
            DropColumn("dbo.Abouts", "AboutContent2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "AboutContent2", c => c.String());
            AddColumn("dbo.Abouts", "AboutContent1", c => c.String());
            DropColumn("dbo.Abouts", "AboutUsInFooter");
            DropColumn("dbo.Abouts", "WhatDoWeDo");
            DropColumn("dbo.Abouts", "WhoAreWeText");
        }
    }
}
