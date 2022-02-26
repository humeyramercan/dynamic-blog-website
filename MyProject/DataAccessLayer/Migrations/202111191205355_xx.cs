namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xx : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SubscribeMails", "Mail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubscribeMails", "Mail", c => c.String(maxLength: 50));
        }
    }
}
