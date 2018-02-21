namespace CoinTrust.Migrations.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removetradepricecolumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Trades", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trades", "Price", c => c.Double(nullable: false));
        }
    }
}
