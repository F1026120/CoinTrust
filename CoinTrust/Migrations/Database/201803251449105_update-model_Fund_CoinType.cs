namespace CoinTrust.Migrations.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodel_Fund_CoinType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RealCoinAccounts", "RealCoinType_RealCoinTypeId", "dbo.RealCoinTypes");
            DropForeignKey("dbo.RealCoinFunds", "RealCoinType_RealCoinTypeId", "dbo.RealCoinTypes");
            DropForeignKey("dbo.TransactionHistories", "RealCoinType_RealCoinTypeId", "dbo.RealCoinTypes");
            DropIndex("dbo.RealCoinAccounts", new[] { "RealCoinType_RealCoinTypeId" });
            DropIndex("dbo.RealCoinFunds", new[] { "RealCoinType_RealCoinTypeId" });
            DropIndex("dbo.TransactionHistories", new[] { "RealCoinType_RealCoinTypeId" });
            RenameColumn(table: "dbo.RealCoinAccounts", name: "RealCoinType_RealCoinTypeId", newName: "RealCoinType_Name");
            RenameColumn(table: "dbo.RealCoinFunds", name: "RealCoinType_RealCoinTypeId", newName: "RealCoinType_Name");
            RenameColumn(table: "dbo.TransactionHistories", name: "RealCoinType_RealCoinTypeId", newName: "RealCoinType_Name");
            DropPrimaryKey("dbo.RealCoinTypes");
            DropPrimaryKey("dbo.RealCoinFunds");
            AddColumn("dbo.RealCoinFunds", "AccountId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.RealCoinAccounts", "RealCoinType_Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.RealCoinTypes", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.RealCoinFunds", "RealCoinType_Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TransactionHistories", "RealCoinType_Name", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.RealCoinTypes", "Name");
            AddPrimaryKey("dbo.RealCoinFunds", "AccountId");
            CreateIndex("dbo.RealCoinAccounts", "RealCoinType_Name");
            CreateIndex("dbo.RealCoinFunds", "RealCoinType_Name");
            CreateIndex("dbo.TransactionHistories", "RealCoinType_Name");
            AddForeignKey("dbo.RealCoinAccounts", "RealCoinType_Name", "dbo.RealCoinTypes", "Name", cascadeDelete: true);
            AddForeignKey("dbo.RealCoinFunds", "RealCoinType_Name", "dbo.RealCoinTypes", "Name", cascadeDelete: true);
            AddForeignKey("dbo.TransactionHistories", "RealCoinType_Name", "dbo.RealCoinTypes", "Name", cascadeDelete: true);
            DropColumn("dbo.RealCoinTypes", "RealCoinTypeId");
            DropColumn("dbo.RealCoinFunds", "RealCoinFundId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RealCoinFunds", "RealCoinFundId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.RealCoinTypes", "RealCoinTypeId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.TransactionHistories", "RealCoinType_Name", "dbo.RealCoinTypes");
            DropForeignKey("dbo.RealCoinFunds", "RealCoinType_Name", "dbo.RealCoinTypes");
            DropForeignKey("dbo.RealCoinAccounts", "RealCoinType_Name", "dbo.RealCoinTypes");
            DropIndex("dbo.TransactionHistories", new[] { "RealCoinType_Name" });
            DropIndex("dbo.RealCoinFunds", new[] { "RealCoinType_Name" });
            DropIndex("dbo.RealCoinAccounts", new[] { "RealCoinType_Name" });
            DropPrimaryKey("dbo.RealCoinFunds");
            DropPrimaryKey("dbo.RealCoinTypes");
            AlterColumn("dbo.TransactionHistories", "RealCoinType_Name", c => c.Int(nullable: false));
            AlterColumn("dbo.RealCoinFunds", "RealCoinType_Name", c => c.Int(nullable: false));
            AlterColumn("dbo.RealCoinTypes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.RealCoinAccounts", "RealCoinType_Name", c => c.Int(nullable: false));
            DropColumn("dbo.RealCoinFunds", "AccountId");
            AddPrimaryKey("dbo.RealCoinFunds", "RealCoinFundId");
            AddPrimaryKey("dbo.RealCoinTypes", "RealCoinTypeId");
            RenameColumn(table: "dbo.TransactionHistories", name: "RealCoinType_Name", newName: "RealCoinType_RealCoinTypeId");
            RenameColumn(table: "dbo.RealCoinFunds", name: "RealCoinType_Name", newName: "RealCoinType_RealCoinTypeId");
            RenameColumn(table: "dbo.RealCoinAccounts", name: "RealCoinType_Name", newName: "RealCoinType_RealCoinTypeId");
            CreateIndex("dbo.TransactionHistories", "RealCoinType_RealCoinTypeId");
            CreateIndex("dbo.RealCoinFunds", "RealCoinType_RealCoinTypeId");
            CreateIndex("dbo.RealCoinAccounts", "RealCoinType_RealCoinTypeId");
            AddForeignKey("dbo.TransactionHistories", "RealCoinType_RealCoinTypeId", "dbo.RealCoinTypes", "RealCoinTypeId", cascadeDelete: true);
            AddForeignKey("dbo.RealCoinFunds", "RealCoinType_RealCoinTypeId", "dbo.RealCoinTypes", "RealCoinTypeId", cascadeDelete: true);
            AddForeignKey("dbo.RealCoinAccounts", "RealCoinType_RealCoinTypeId", "dbo.RealCoinTypes", "RealCoinTypeId", cascadeDelete: true);
        }
    }
}
