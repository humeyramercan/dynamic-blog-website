namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig213 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "UserName", c => c.String());
            AlterColumn("dbo.Comments", "Mail", c => c.String());
            AlterColumn("dbo.Comments", "CommentText", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "CommentText", c => c.String(maxLength: 300));
            AlterColumn("dbo.Comments", "Mail", c => c.String(maxLength: 50));
            AlterColumn("dbo.Comments", "UserName", c => c.String(maxLength: 50));
        }
    }
}
