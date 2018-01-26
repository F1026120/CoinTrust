namespace CoinTrust.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
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
            
            CreateTable(
                "dbo.RealCoinTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        address_regex = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionHistories", "user_email_ref", "dbo.Users");
            DropForeignKey("dbo.TransactionHistories", "real_coin_type_id", "dbo.RealCoinTypes");
            DropIndex("dbo.TransactionHistories", new[] { "real_coin_type_id" });
            DropIndex("dbo.TransactionHistories", new[] { "user_email_ref" });
            DropTable("dbo.RealCoinTypes");
            DropTable("dbo.TransactionHistories");
            DropTable("dbo.Users");
        }
    }
}
