namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class authorfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "AuthorTitle", c => c.String());
            AddColumn("dbo.Authors", "AboutShort", c => c.String());
            AddColumn("dbo.Authors", "AuthorMail", c => c.String());
            AddColumn("dbo.Authors", "AuthorPassword", c => c.String());
            AddColumn("dbo.Authors", "AuthorPhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "AuthorPhoneNumber");
            DropColumn("dbo.Authors", "AuthorPassword");
            DropColumn("dbo.Authors", "AuthorMail");
            DropColumn("dbo.Authors", "AboutShort");
            DropColumn("dbo.Authors", "AuthorTitle");
        }
    }
}
