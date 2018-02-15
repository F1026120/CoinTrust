namespace CoinTrust.Migrations.TestCar
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
            MigrationsDirectory = @"Migrations\TestCar";
        }

        protected override void Seed(CoinTrust.DataAccessLayer.TestCarContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            /*
             * Car  Owner   type    wheel
             * gtr  YY      C       16 17
             * gt86 PL      D       17 18
             * z4   YY      B       16 18
             * m5   YY      A       17 19
             */

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

            gtr.Name = "GTR";
            gtr.TestCarWheel = new List<TestCarWheel> { wh16, wh17 };
            gtr.TestCarOwner = YY;

            gt86.Name = "GT86";
            gt86.TestCarWheel = new List<TestCarWheel> { wh17, wh18 };
            gt86.TestCarOwner = PL;

            z4.Name = "Z4";
            z4.TestCarWheel = new List<TestCarWheel> { wh16, wh18 };
            z4.TestCarOwner = YY;

            m5.Name = "M5";
            m5.TestCarWheel = new List<TestCarWheel> { wh17, wh19 };
            m5.TestCarOwner = YY;

            YY.TestCar = new List<TestCar> { gtr, z4, m5 };
            YY.Name = "Yung Yuan";
            PL.TestCar = new List<TestCar> { gt86};
            PL.Name = "Pin Lun";

            wh16.TestCar = new List<TestCar> { gtr, z4 };
            wh16.Size = 16;
            wh17.TestCar = new List<TestCar> { gtr, gt86 ,m5};
            wh17.Size = 17;
            wh18.TestCar = new List<TestCar> { gt86, z4 };
            wh18.Size = 18;
            wh19.TestCar = new List<TestCar> { m5 };
            wh19.Size = 19;

            context.TestCarOwner.Add(YY);
            context.TestCarOwner.Add(PL);

            context.TestCarWheel.Add(wh16);
            context.TestCarWheel.Add(wh17);
            context.TestCarWheel.Add(wh18);
            context.TestCarWheel.Add(wh19);

            context.TestCar.Add(gtr);
            context.TestCar.Add(gt86);
            context.TestCar.Add(z4);
            context.TestCar.Add(m5);
            context.SaveChanges();

            gtrk.Type = "C";
            gtrk.TestCarId = gtr.CarId;
            gt86k.Type = "D";
            gt86k.TestCarId = gt86.CarId;
            z4k.Type = "B";
            z4k.TestCarId = z4.CarId;
            m5k.Type = "A";
            m5k.TestCarId = m5.CarId;
            context.TestCarKey.Add(gtrk);
            context.TestCarKey.Add(gt86k);
            context.TestCarKey.Add(z4k);
            context.TestCarKey.Add(m5k);
            context.SaveChanges();
        }
    }
}
