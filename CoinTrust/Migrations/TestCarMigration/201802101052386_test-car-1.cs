namespace CoinTrust.Migrations.TestCarMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testcar1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestCars",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        test_car_owner_id = c.Int(nullable: false),
                        test_car_wheel_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TestCarOwners", t => t.test_car_owner_id, cascadeDelete: true)
                .Index(t => t.test_car_owner_id);
            
            CreateTable(
                "dbo.TestCarOwners",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        test_car_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TestCarWheels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        test_car_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TestCarKeys",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        test_car_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TestCars", t => t.test_car_id, cascadeDelete: true)
                .Index(t => t.test_car_id);
            
            CreateTable(
                "dbo.TestCarWheelTestCars",
                c => new
                    {
                        TestCarWheel_id = c.Int(nullable: false),
                        TestCar_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TestCarWheel_id, t.TestCar_id })
                .ForeignKey("dbo.TestCarWheels", t => t.TestCarWheel_id, cascadeDelete: true)
                .ForeignKey("dbo.TestCars", t => t.TestCar_id, cascadeDelete: true)
                .Index(t => t.TestCarWheel_id)
                .Index(t => t.TestCar_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestCarKeys", "test_car_id", "dbo.TestCars");
            DropForeignKey("dbo.TestCarWheelTestCars", "TestCar_id", "dbo.TestCars");
            DropForeignKey("dbo.TestCarWheelTestCars", "TestCarWheel_id", "dbo.TestCarWheels");
            DropForeignKey("dbo.TestCars", "test_car_owner_id", "dbo.TestCarOwners");
            DropIndex("dbo.TestCarWheelTestCars", new[] { "TestCar_id" });
            DropIndex("dbo.TestCarWheelTestCars", new[] { "TestCarWheel_id" });
            DropIndex("dbo.TestCarKeys", new[] { "test_car_id" });
            DropIndex("dbo.TestCars", new[] { "test_car_owner_id" });
            DropTable("dbo.TestCarWheelTestCars");
            DropTable("dbo.TestCarKeys");
            DropTable("dbo.TestCarWheels");
            DropTable("dbo.TestCarOwners");
            DropTable("dbo.TestCars");
        }
    }
}
