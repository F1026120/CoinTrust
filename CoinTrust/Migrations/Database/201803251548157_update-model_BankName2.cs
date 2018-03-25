namespace CoinTrust.Migrations.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodel_BankName2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RealCoinAccounts", "BankName", c => c.String(nullable: false));
            DropColumn("dbo.DigitCoinAccounts", "BankName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DigitCoinAccounts", "BankName", c => c.String(nullable: false));
            DropColumn("dbo.RealCoinAccounts", "BankName");
        }
    }
}
