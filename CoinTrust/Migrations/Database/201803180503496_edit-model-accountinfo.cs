namespace CoinTrust.Migrations.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editmodelaccountinfo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LoginHistories", "Locale", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LoginHistories", "Locale", c => c.String(nullable: false));
        }
    }
}
