namespace CoinTrust.Migrations.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodel_BankName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DigitCoinAccounts", "BankName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DigitCoinAccounts", "BankName");
        }
    }
}
