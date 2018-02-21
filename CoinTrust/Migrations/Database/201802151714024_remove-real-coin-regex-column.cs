namespace CoinTrust.Migrations.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removerealcoinregexcolumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RealCoinTypes", "AddressRegex");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RealCoinTypes", "AddressRegex", c => c.String(nullable: false));
        }
    }
}
