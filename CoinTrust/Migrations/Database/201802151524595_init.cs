namespace CoinTrust.Migrations.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 10),
                        Certification = c.Boolean(nullable: false),
                        UsePhoneAuthenticator = c.Boolean(nullable: false),
                        UseGoogleAuthenticator = c.Boolean(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.DigitCoinAccounts",
                c => new
                    {
                        DigitCoinAccountId = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false),
                        DigitCoinType_DigitCoinTypeId = c.Int(nullable: false),
                        User_AccountId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.DigitCoinAccountId)
                .ForeignKey("dbo.DigitCoinTypes", t => t.DigitCoinType_DigitCoinTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.User_AccountId, cascadeDelete: true)
                .Index(t => t.DigitCoinType_DigitCoinTypeId)
                .Index(t => t.User_AccountId);
            
            CreateTable(
                "dbo.DigitCoinTypes",
                c => new
                    {
                        DigitCoinTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AddressRegex = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DigitCoinTypeId);
            
            CreateTable(
                "dbo.LoginHistories",
                c => new
                    {
                        LoginHistoryId = c.Int(nullable: false, identity: true),
                        Ip = c.String(nullable: false),
                        Locale = c.String(nullable: false),
                        LoginAt = c.DateTime(nullable: false),
                        User_AccountId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.LoginHistoryId)
                .ForeignKey("dbo.Accounts", t => t.User_AccountId, cascadeDelete: true)
                .Index(t => t.User_AccountId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        Quantity = c.Single(nullable: false),
                        RemainQuantity = c.Single(nullable: false),
                        MinQuantity = c.Single(nullable: false),
                        Address = c.String(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                        DigitCoinType_DigitCoinTypeId = c.Int(nullable: false),
                        Seller_AccountId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.DigitCoinTypes", t => t.DigitCoinType_DigitCoinTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.Seller_AccountId, cascadeDelete: true)
                .Index(t => t.DigitCoinType_DigitCoinTypeId)
                .Index(t => t.Seller_AccountId);
            
            CreateTable(
                "dbo.RealCoinAccounts",
                c => new
                    {
                        RealCoinAccountId = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false),
                        RealCoinType_RealCoinTypeId = c.Int(nullable: false),
                        User_AccountId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.RealCoinAccountId)
                .ForeignKey("dbo.RealCoinTypes", t => t.RealCoinType_RealCoinTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.User_AccountId, cascadeDelete: true)
                .Index(t => t.RealCoinType_RealCoinTypeId)
                .Index(t => t.User_AccountId);
            
            CreateTable(
                "dbo.RealCoinTypes",
                c => new
                    {
                        RealCoinTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AddressRegex = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RealCoinTypeId);
            
            CreateTable(
                "dbo.RealCoinFunds",
                c => new
                    {
                        RealCoinFundId = c.Int(nullable: false, identity: true),
                        CoinStatus = c.Int(nullable: false),
                        Amount = c.Single(nullable: false),
                        RealCoinType_RealCoinTypeId = c.Int(nullable: false),
                        User_AccountId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.RealCoinFundId)
                .ForeignKey("dbo.RealCoinTypes", t => t.RealCoinType_RealCoinTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.User_AccountId, cascadeDelete: true)
                .Index(t => t.RealCoinType_RealCoinTypeId)
                .Index(t => t.User_AccountId);
            
            CreateTable(
                "dbo.ResetPasswords",
                c => new
                    {
                        email = c.String(nullable: false, maxLength: 128),
                        old_password = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.email);
            
            CreateTable(
                "dbo.Trades",
                c => new
                    {
                        TradeId = c.Int(nullable: false, identity: true),
                        Quantity = c.Single(nullable: false),
                        Price = c.Single(nullable: false),
                        TradeStatus = c.Int(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        Order_OrderId = c.Int(nullable: false),
                        Buyer_AccountId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.TradeId)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.Buyer_AccountId, cascadeDelete: false)
                .Index(t => t.Order_OrderId)
                .Index(t => t.Buyer_AccountId);

            CreateTable(
                "dbo.TransactionHistories",
                c => new
                    {
                        TransactionHistoryId = c.Int(nullable: false, identity: true),
                        Amount = c.Single(nullable: false),
                        TransactionStatus = c.Int(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        RealCoinType_RealCoinTypeId = c.Int(nullable: false),
                        User_AccountId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.TransactionHistoryId)
                .ForeignKey("dbo.RealCoinTypes", t => t.RealCoinType_RealCoinTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.User_AccountId, cascadeDelete: true)
                .Index(t => t.RealCoinType_RealCoinTypeId)
                .Index(t => t.User_AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionHistories", "User_AccountId", "dbo.Accounts");
            DropForeignKey("dbo.TransactionHistories", "RealCoinType_RealCoinTypeId", "dbo.RealCoinTypes");
            DropForeignKey("dbo.Trades", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.RealCoinFunds", "User_AccountId", "dbo.Accounts");
            DropForeignKey("dbo.RealCoinFunds", "RealCoinType_RealCoinTypeId", "dbo.RealCoinTypes");
            DropForeignKey("dbo.RealCoinAccounts", "User_AccountId", "dbo.Accounts");
            DropForeignKey("dbo.RealCoinAccounts", "RealCoinType_RealCoinTypeId", "dbo.RealCoinTypes");
            DropForeignKey("dbo.Orders", "Seller_AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Orders", "DigitCoinType_DigitCoinTypeId", "dbo.DigitCoinTypes");
            DropForeignKey("dbo.LoginHistories", "User_AccountId", "dbo.Accounts");
            DropForeignKey("dbo.DigitCoinAccounts", "User_AccountId", "dbo.Accounts");
            DropForeignKey("dbo.DigitCoinAccounts", "DigitCoinType_DigitCoinTypeId", "dbo.DigitCoinTypes");
            DropIndex("dbo.TransactionHistories", new[] { "User_AccountId" });
            DropIndex("dbo.TransactionHistories", new[] { "RealCoinType_RealCoinTypeId" });
            DropIndex("dbo.Trades", new[] { "Order_OrderId" });
            DropIndex("dbo.RealCoinFunds", new[] { "User_AccountId" });
            DropIndex("dbo.RealCoinFunds", new[] { "RealCoinType_RealCoinTypeId" });
            DropIndex("dbo.RealCoinAccounts", new[] { "User_AccountId" });
            DropIndex("dbo.RealCoinAccounts", new[] { "RealCoinType_RealCoinTypeId" });
            DropIndex("dbo.Orders", new[] { "Seller_AccountId" });
            DropIndex("dbo.Orders", new[] { "DigitCoinType_DigitCoinTypeId" });
            DropIndex("dbo.LoginHistories", new[] { "User_AccountId" });
            DropIndex("dbo.DigitCoinAccounts", new[] { "User_AccountId" });
            DropIndex("dbo.DigitCoinAccounts", new[] { "DigitCoinType_DigitCoinTypeId" });
            DropTable("dbo.TransactionHistories");
            DropTable("dbo.Trades");
            DropTable("dbo.ResetPasswords");
            DropTable("dbo.RealCoinFunds");
            DropTable("dbo.RealCoinTypes");
            DropTable("dbo.RealCoinAccounts");
            DropTable("dbo.Orders");
            DropTable("dbo.LoginHistories");
            DropTable("dbo.DigitCoinTypes");
            DropTable("dbo.DigitCoinAccounts");
            DropTable("dbo.Accounts");
        }
    }
}
