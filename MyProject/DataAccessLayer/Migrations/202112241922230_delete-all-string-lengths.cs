namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteallstringlengths : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abouts", "AboutContent1", c => c.String());
            AlterColumn("dbo.Abouts", "AboutContent2", c => c.String());
            AlterColumn("dbo.Abouts", "AboutImage1", c => c.String());
            AlterColumn("dbo.Abouts", "AboutImage2", c => c.String());
            AlterColumn("dbo.Admins", "UserName", c => c.String());
            AlterColumn("dbo.Admins", "Password", c => c.String());
            AlterColumn("dbo.Authors", "AuthorName", c => c.String());
            AlterColumn("dbo.Authors", "AuthorImage", c => c.String());
            AlterColumn("dbo.Blogs", "BlogTitle", c => c.String());
            AlterColumn("dbo.Blogs", "BlogImage", c => c.String());
            AlterColumn("dbo.Contacts", "Name", c => c.String());
            AlterColumn("dbo.Contacts", "Surname", c => c.String());
            AlterColumn("dbo.Contacts", "Mail", c => c.String());
            AlterColumn("dbo.Contacts", "Subject", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Subject", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "Mail", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "Surname", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Blogs", "BlogImage", c => c.String(maxLength: 200));
            AlterColumn("dbo.Blogs", "BlogTitle", c => c.String(maxLength: 100));
            AlterColumn("dbo.Authors", "AuthorImage", c => c.String(maxLength: 100));
            AlterColumn("dbo.Authors", "AuthorName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Admins", "Password", c => c.String(maxLength: 20));
            AlterColumn("dbo.Admins", "UserName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Abouts", "AboutImage2", c => c.String(maxLength: 100));
            AlterColumn("dbo.Abouts", "AboutImage1", c => c.String(maxLength: 100));
            AlterColumn("dbo.Abouts", "AboutContent2", c => c.String(maxLength: 500));
            AlterColumn("dbo.Abouts", "AboutContent1", c => c.String(maxLength: 500));
        }
    }
}
