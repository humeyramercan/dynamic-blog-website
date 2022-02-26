namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categorydescr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
            AlterColumn("dbo.Categories", "CategoryDescription", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "CategoryDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(maxLength: 30));
        }
    }
}
