namespace CoinTrust.Migrations.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.Orders", "Quantity", c => c.Double(nullable: false));
            AlterColumn("dbo.Orders", "RemainQuantity", c => c.Double(nullable: false));
            AlterColumn("dbo.Orders", "MinQuantity", c => c.Double(nullable: false));
            AlterColumn("dbo.RealCoinFunds", "Amount", c => c.Double(nullable: false));
            AlterColumn("dbo.Trades", "Quantity", c => c.Double(nullable: false));
            AlterColumn("dbo.Trades", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.TransactionHistories", "Amount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TransactionHistories", "Amount", c => c.Single(nullable: false));
            AlterColumn("dbo.Trades", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.Trades", "Quantity", c => c.Single(nullable: false));
            AlterColumn("dbo.RealCoinFunds", "Amount", c => c.Single(nullable: false));
            AlterColumn("dbo.Orders", "MinQuantity", c => c.Single(nullable: false));
            AlterColumn("dbo.Orders", "RemainQuantity", c => c.Single(nullable: false));
            AlterColumn("dbo.Orders", "Quantity", c => c.Single(nullable: false));
            AlterColumn("dbo.Orders", "Price", c => c.Single(nullable: false));
        }
    }
}
