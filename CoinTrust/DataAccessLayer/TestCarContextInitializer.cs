using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CoinTrust.Models;

namespace CoinTrust.DataAccessLayer
{
    public class TestCarContextInitializer : DropCreateDatabaseAlways<TestCarContext>
    {
        //    protected override void Seed(CoinTrust.DataAccessLayer.TestCarContext context)
        //    {
        //        base.Seed(context);
        //        //  This method will be called after migrating to the latest version.

        //        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //        //  to avoid creating duplicate seed data.

        //        //  This method will be called after migrating to the latest version.

        //        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //        //  to avoid creating duplicate seed data.
        //        TestCar gtr = new TestCar();
        //        TestCar gt86 = new TestCar();
        //        TestCar z4 = new TestCar();
        //        TestCar m5 = new TestCar();

        //        TestCarKey gtrk = new TestCarKey();
        //        TestCarKey gt86k = new TestCarKey();
        //        TestCarKey z4k = new TestCarKey();
        //        TestCarKey m5k = new TestCarKey();

        //        TestCarOwner yy = new TestCarOwner();
        //        TestCarOwner pl = new TestCarOwner();

        //        TestCarWheel w1 = new TestCarWheel();
        //        TestCarWheel w2 = new TestCarWheel();
        //        TestCarWheel w3 = new TestCarWheel();
        //        TestCarWheel w4 = new TestCarWheel();
        //        TestCarWheel w5 = new TestCarWheel();
        //        TestCarWheel w6 = new TestCarWheel();
        //        TestCarWheel w7 = new TestCarWheel();
        //        TestCarWheel w8 = new TestCarWheel();
        //        var gtrwl = new List<TestCarWheel>
        //        {
        //            w1,
        //            w2
        //        };
        //        var gt86wl = new List<TestCarWheel>
        //        {
        //            w3,
        //            w4
        //        };
        //        var z4wl = new List<TestCarWheel>
        //        {
        //            w5,
        //            w6
        //        };
        //        var m5rwl = new List<TestCarWheel>
        //        {
        //            w7,
        //            w8
        //        };
        //        //一個人可以有很多車
        //        gtr.test_car_owner_id = yy.id;
        //        gt86.test_car_owner_id = pl.id;
        //        z4.test_car_owner_id = yy.id;
        //        m5.test_car_owner_id = pl.id;

        //        //一台車只有一支鑰匙
        //        gtrk.test_car_id = gtr.id;
        //        gt86k.test_car_id = gt86.id;
        //        z4k.test_car_id = z4.id;
        //        m5k.test_car_id = m5.id;
        //        //每台車都可以有很多個輪子


        //        context.TestCar.Add(gtr);
        //        context.TestCar.Add(gt86);
        //        context.TestCar.Add(z4);
        //        context.TestCar.Add(m5);

        //        context.TestCarKey.Add(gtrk);
        //        context.TestCarKey.Add(gt86k);
        //        context.TestCarKey.Add(z4k);
        //        context.TestCarKey.Add(m5k);

        //        context.TestCarOwner.Add(yy);
        //        context.TestCarOwner.Add(pl);

        //        context.TestCarWheel.Add(w1);
        //        context.TestCarWheel.Add(w2);
        //        context.TestCarWheel.Add(w3);
        //        context.TestCarWheel.Add(w4);
        //        context.TestCarWheel.Add(w5);
        //        context.TestCarWheel.Add(w6);
        //        context.TestCarWheel.Add(w7);
        //        context.TestCarWheel.Add(w8);

        //        context.SaveChanges();
        //    }
    }
}