namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blogcoverimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogCoverImage", c => c.String());
            DropColumn("dbo.Blogs", "BlogImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "BlogImage", c => c.String());
            DropColumn("dbo.Blogs", "BlogCoverImage");
        }
    }
}
