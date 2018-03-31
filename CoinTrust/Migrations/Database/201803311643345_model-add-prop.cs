namespace CoinTrust.Migrations.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modeladdprop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trades", "BuyerAddress", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trades", "BuyerAddress");
        }
    }
}
