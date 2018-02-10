namespace CoinTrust.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DigitCoinAccounts",
                c => new
                    {
                        address = c.String(nullable: false, maxLength: 128),
                        user_id = c.String(nullable: false, maxLength: 128),
                        digit_coin_type_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.address)
                .ForeignKey("dbo.DigitCoinTypes", t => t.digit_coin_type_id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id)
                .Index(t => t.digit_coin_type_id);
            
            CreateTable(
                "dbo.DigitCoinTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        address_regex = c.String(nullable: false),
                        address_regex_checksum = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        email = c.String(nullable: false, maxLength: 128),
                        password = c.String(nullable: false),
                        phone = c.String(nullable: false, maxLength: 10),
                        certification = c.Boolean(nullable: false),
                        use_phone_authenticator = c.Boolean(nullable: false),
                        use_google_authenticator = c.Boolean(nullable: false),
                        create_at = c.DateTime(nullable: false),
                        update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.email);
            
            CreateTable(
                "dbo.LogonHistories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        user_id = c.String(nullable: false, maxLength: 128),
                        ip_address = c.String(nullable: false),
                        locale = c.String(nullable: false),
                        logon_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        seller_id = c.String(nullable: false, maxLength: 128),
                        digit_coin_type_id = c.Int(nullable: false),
                        price = c.Single(nullable: false),
                        quantity = c.Single(nullable: false),
                        remain_quantity = c.Single(nullable: false),
                        min_quantity = c.Single(nullable: false),
                        address = c.String(nullable: false),
                        order_status_id = c.Int(nullable: false),
                        create_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.DigitCoinTypes", t => t.digit_coin_type_id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.seller_id, cascadeDelete: true)
                .Index(t => t.seller_id)
                .Index(t => t.digit_coin_type_id);
            
            CreateTable(
                "dbo.RealCoinAccounts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        user_id = c.String(nullable: false, maxLength: 128),
                        real_coin_type_id = c.Int(nullable: false),
                        address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RealCoinTypes", t => t.real_coin_type_id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id)
                .Index(t => t.real_coin_type_id);
            
            CreateTable(
                "dbo.RealCoinTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        address_regex = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.RealCoinFunds",
                c => new
                    {
                        user_id = c.String(nullable: false, maxLength: 128),
                        real_coin_type_id = c.Int(nullable: false),
                        coin_status = c.Int(nullable: false),
                        amount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.user_id)
                .ForeignKey("dbo.RealCoinTypes", t => t.real_coin_type_id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.user_id)
                .Index(t => t.user_id)
                .Index(t => t.real_coin_type_id);
            
            CreateTable(
                "dbo.Trades",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        order_id = c.Int(nullable: false),
                        buyer_id = c.String(nullable: false, maxLength: 128),
                        quantity = c.Single(nullable: false),
                        price = c.Single(nullable: false),
                        trade_status = c.Int(nullable: false),
                        create_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.buyer_id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.order_id, cascadeDelete: true)
                .Index(t => t.order_id)
                .Index(t => t.buyer_id);
            
            CreateTable(
                "dbo.TransactionHistories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        user_email_ref = c.String(nullable: false, maxLength: 128),
                        real_coin_type_id = c.Int(nullable: false),
                        amount = c.Single(nullable: false),
                        transaction_status = c.Int(nullable: false),
                        create_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RealCoinTypes", t => t.real_coin_type_id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.user_email_ref, cascadeDelete: true)
                .Index(t => t.user_email_ref)
                .Index(t => t.real_coin_type_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionHistories", "user_email_ref", "dbo.Users");
            DropForeignKey("dbo.TransactionHistories", "real_coin_type_id", "dbo.RealCoinTypes");
            DropForeignKey("dbo.Trades", "order_id", "dbo.Orders");
            DropForeignKey("dbo.Trades", "buyer_id", "dbo.Users");
            DropForeignKey("dbo.RealCoinFunds", "user_id", "dbo.Users");
            DropForeignKey("dbo.RealCoinFunds", "real_coin_type_id", "dbo.RealCoinTypes");
            DropForeignKey("dbo.RealCoinAccounts", "user_id", "dbo.Users");
            DropForeignKey("dbo.RealCoinAccounts", "real_coin_type_id", "dbo.RealCoinTypes");
            DropForeignKey("dbo.Orders", "seller_id", "dbo.Users");
            DropForeignKey("dbo.Orders", "digit_coin_type_id", "dbo.DigitCoinTypes");
            DropForeignKey("dbo.LogonHistories", "user_id", "dbo.Users");
            DropForeignKey("dbo.DigitCoinAccounts", "user_id", "dbo.Users");
            DropForeignKey("dbo.DigitCoinAccounts", "digit_coin_type_id", "dbo.DigitCoinTypes");
            DropIndex("dbo.TransactionHistories", new[] { "real_coin_type_id" });
            DropIndex("dbo.TransactionHistories", new[] { "user_email_ref" });
            DropIndex("dbo.Trades", new[] { "buyer_id" });
            DropIndex("dbo.Trades", new[] { "order_id" });
            DropIndex("dbo.RealCoinFunds", new[] { "real_coin_type_id" });
            DropIndex("dbo.RealCoinFunds", new[] { "user_id" });
            DropIndex("dbo.RealCoinAccounts", new[] { "real_coin_type_id" });
            DropIndex("dbo.RealCoinAccounts", new[] { "user_id" });
            DropIndex("dbo.Orders", new[] { "digit_coin_type_id" });
            DropIndex("dbo.Orders", new[] { "seller_id" });
            DropIndex("dbo.LogonHistories", new[] { "user_id" });
            DropIndex("dbo.DigitCoinAccounts", new[] { "digit_coin_type_id" });
            DropIndex("dbo.DigitCoinAccounts", new[] { "user_id" });
            DropTable("dbo.TransactionHistories");
            DropTable("dbo.Trades");
            DropTable("dbo.RealCoinFunds");
            DropTable("dbo.RealCoinTypes");
            DropTable("dbo.RealCoinAccounts");
            DropTable("dbo.Orders");
            DropTable("dbo.LogonHistories");
            DropTable("dbo.Users");
            DropTable("dbo.DigitCoinTypes");
            DropTable("dbo.DigitCoinAccounts");
        }
    }
}
