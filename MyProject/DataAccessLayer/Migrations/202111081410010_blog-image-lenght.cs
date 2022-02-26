namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blogimagelenght : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "BlogImage", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "BlogImage", c => c.String(maxLength: 100));
        }
    }
}
