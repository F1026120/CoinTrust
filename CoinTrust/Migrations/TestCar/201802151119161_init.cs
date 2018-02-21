namespace CoinTrust.Migrations.TestCar
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestCars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TestCarOwner_OwnerId = c.Int(),
                    })
                .PrimaryKey(t => t.CarId)
                .ForeignKey("dbo.TestCarOwners", t => t.TestCarOwner_OwnerId)
                .Index(t => t.TestCarOwner_OwnerId);
            
            CreateTable(
                "dbo.TestCarOwners",
                c => new
                    {
                        OwnerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.OwnerId);
            
            CreateTable(
                "dbo.TestCarWheels",
                c => new
                    {
                        TestCarWheelId = c.Int(nullable: false, identity: true),
                        Size = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestCarWheelId);
            
            CreateTable(
                "dbo.TestCarKeys",
                c => new
                    {
                        TestCarId = c.Int(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.TestCarId)
                .ForeignKey("dbo.TestCars", t => t.TestCarId)
                .Index(t => t.TestCarId);
            
            CreateTable(
                "dbo.TestCarWheelTestCars",
                c => new
                    {
                        TestCarWheel_TestCarWheelId = c.Int(nullable: false),
                        TestCar_CarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TestCarWheel_TestCarWheelId, t.TestCar_CarId })
                .ForeignKey("dbo.TestCarWheels", t => t.TestCarWheel_TestCarWheelId, cascadeDelete: true)
                .ForeignKey("dbo.TestCars", t => t.TestCar_CarId, cascadeDelete: true)
                .Index(t => t.TestCarWheel_TestCarWheelId)
                .Index(t => t.TestCar_CarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestCarKeys", "TestCarId", "dbo.TestCars");
            DropForeignKey("dbo.TestCarWheelTestCars", "TestCar_CarId", "dbo.TestCars");
            DropForeignKey("dbo.TestCarWheelTestCars", "TestCarWheel_TestCarWheelId", "dbo.TestCarWheels");
            DropForeignKey("dbo.TestCars", "TestCarOwner_OwnerId", "dbo.TestCarOwners");
            DropIndex("dbo.TestCarWheelTestCars", new[] { "TestCar_CarId" });
            DropIndex("dbo.TestCarWheelTestCars", new[] { "TestCarWheel_TestCarWheelId" });
            DropIndex("dbo.TestCarKeys", new[] { "TestCarId" });
            DropIndex("dbo.TestCars", new[] { "TestCarOwner_OwnerId" });
            DropTable("dbo.TestCarWheelTestCars");
            DropTable("dbo.TestCarKeys");
            DropTable("dbo.TestCarWheels");
            DropTable("dbo.TestCarOwners");
            DropTable("dbo.TestCars");
        }
    }
}
