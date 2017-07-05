namespace DogParksForBlaze.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateTimeToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DogParkDateAccounts", "CreatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DogParkDateAccounts", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
