namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig234234 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "AuthorPhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "AuthorPhoneNumber", c => c.String());
        }
    }
}
