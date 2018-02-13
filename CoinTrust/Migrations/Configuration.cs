namespace CoinTrust.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CoinTrust.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CoinTrust.DataAccessLayer.TestCarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CoinTrust.DataAccessLayer.TestCarContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            TestCar gtr = new TestCar();
            TestCar gt86 = new TestCar();
            TestCar z4 = new TestCar();
            TestCar m5 = new TestCar();

            TestCarKey gtrk = new TestCarKey();
            TestCarKey gt86k = new TestCarKey();
            TestCarKey z4k = new TestCarKey();
            TestCarKey m5k = new TestCarKey();

            TestCarOwner YY = new TestCarOwner();
            TestCarOwner PL = new TestCarOwner();

            TestCarWheel wh16 = new TestCarWheel();
            TestCarWheel wh17 = new TestCarWheel();
            TestCarWheel wh18 = new TestCarWheel();
            TestCarWheel wh19 = new TestCarWheel();



            gtr.name = "GTR";
            gtr.test_car_owner = YY;

            gt86.name = "GT86";
            gt86.test_car_owner = PL;

            z4.name = "Z4";
            z4.test_car_owner = YY;

            m5.name = "M5";
            m5.test_car_owner = YY;

            gtrk.type = "C";
            gt86k.type = "D";
            z4k.type = "B";
            m5k.type = "A";

            wh16.size = 16;
            wh17.size = 17;
            wh18.size = 18;
            wh19.size = 19;



            gtr.test_car_wheel = new List<TestCarWheel> { wh16, wh17 };
            gt86.test_car_wheel = new List<TestCarWheel> { wh17, wh18 };
            z4.test_car_wheel = new List<TestCarWheel> { wh16, wh18 };
            m5.test_car_wheel = new List<TestCarWheel> { wh17, wh19 };
            gtr.test_car_owner = YY;
            gt86.test_car_owner = PL;
            z4.test_car_owner = YY;
            m5.test_car_owner = PL;

            wh16.test_car = new List<TestCar> { gtr, z4 };
            wh17.test_car = new List<TestCar> { gtr, gt86, m5 };
            wh18.test_car = new List<TestCar> { gt86, z4 };
            wh19.test_car = new List<TestCar> { m5 };


            context.TestCar.Add(gtr);
            context.TestCar.Add(gt86);
            context.TestCar.Add(z4);
            context.TestCar.Add(m5);
            context.TestCarOwner.Add(YY);
            context.TestCarOwner.Add(PL);

            context.SaveChanges();


        }
    }
}
