namespace DogParksForBlaze.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Attributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.dogParkDateAccounts", "UserName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.dogParkDateAccounts", "EmailAddress", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.dogParkDateAccounts", "EmailAddress", c => c.String());
            AlterColumn("dbo.dogParkDateAccounts", "UserName", c => c.String());
        }
    }
}
