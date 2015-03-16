using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.Expressions;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private static Dictionary<string, object> s_propertyNames = null;

        [ClassInitialize]
        public static void Before(TestContext context)
        {
            if (s_propertyNames == null)
            {
                s_propertyNames = new Dictionary<string, object>();
                s_propertyNames.Add("ProductKey", 111);
                s_propertyNames.Add("DateKey", 1112);
                s_propertyNames.Add("MovementDate", DateTime.Now);
                s_propertyNames.Add("UnitCost", 23m);
                s_propertyNames.Add("UnitsIn", 1);
                s_propertyNames.Add("UnitsOut", 2);
                s_propertyNames.Add("UnitsBalance", 5);
            }
        }

        [TestMethod]
        public void GetValue_Test()
        {
            var runTimes = 776286;
            var expected = new FactProductInventory();

            var dynamicProperty = new DynamicProperty<FactProductInventory>();
            var reflectionProperty = new ReflectionProperty<FactProductInventory>();
            var test1 = new TestInfo(() =>
            {
                var dateKey = expected.DateKey;
                var movementDate = expected.MovementDate;
                var productKey = expected.ProductKey;
                var unitCost = expected.UnitCost;
                var unitsBalance = expected.UnitsBalance;
                var unitsIn = expected.UnitsIn;
                var unitsOut = expected.UnitsOut;
            }, "直接指定,GetValue");
            test1.Run(runTimes);

            var test2 = new TestInfo(() =>
            {
                foreach (var propertyName in s_propertyNames)
                {
                    var field = propertyName.Key;
                    var value = dynamicProperty.GetValue(expected, field);
                }
            }, "Expression反射,GetValue");
            test2.Run(runTimes);

            var test3 = new TestInfo(() =>
            {
                foreach (var propertyName in s_propertyNames)
                {
                    var field = propertyName.Key;
                    var value = reflectionProperty.GetValue(expected, field);
                }
            }, "Reflection反射,GetValue");
            test3.Run(runTimes);

            Assert.AreEqual(test1.RunCount, runTimes);
            Assert.AreEqual(test2.RunCount, runTimes);
            Assert.AreEqual(test3.RunCount, runTimes);
        }

        [TestMethod]
        public void SetValue_Test()
        {
            var runTimes = 776286;

            var dynamicProperty = new DynamicProperty<FactProductInventory>();
            var reflectionProperty = new ReflectionProperty<FactProductInventory>();

            var test1 = new TestInfo(() =>
            {
                var inventory = new FactProductInventory();

                inventory.DateKey = 1;
                inventory.MovementDate = DateTime.Now;
                inventory.ProductKey = 1;
                inventory.UnitCost = 2.1m;
                inventory.UnitsBalance = 2;
                inventory.UnitsIn = 2;
                inventory.UnitsOut = 2;
            }, "直接指定,SetValue");
            test1.Run(runTimes);

            var test2 = new TestInfo(() =>
            {
                var inventory = new FactProductInventory();
                foreach (var propertyName in s_propertyNames)
                {
                    var field = propertyName.Key;
                    var value = propertyName.Value;
                    dynamicProperty.SetValue(inventory, field, value);
                }
            }, "Expression反射,SetValue");
            test2.Run(runTimes);

            var test3 = new TestInfo(() =>
            {
                var inventory = new FactProductInventory();

                foreach (var propertyName in s_propertyNames)
                {
                    var field = propertyName.Key;
                    var value = propertyName.Value;
                    reflectionProperty.SetValue(inventory, field, value);
                }
            }, "Reflection反射,SetValue");
            test3.Run(runTimes);

            Assert.AreEqual(test1.RunCount, runTimes);
            Assert.AreEqual(test2.RunCount, runTimes);
            Assert.AreEqual(test3.RunCount, runTimes);
        }

        [TestMethod]
        public void GetAndSetValue_Test()
        {
            var runTimes = 776286;
            var expected = new FactProductInventory();

            var dynamicProperty = new DynamicProperty<FactProductInventory>();
            var reflectionProperty = new ReflectionProperty<FactProductInventory>();

            var test1 = new TestInfo(() =>
            {
                var inventory = new FactProductInventory();
                inventory.DateKey = expected.DateKey;
                inventory.MovementDate = expected.MovementDate;
                inventory.ProductKey = expected.ProductKey;
                inventory.UnitCost = expected.UnitCost;
                inventory.UnitsBalance = expected.UnitsBalance;
                inventory.UnitsIn = expected.UnitsIn;
                inventory.UnitsOut = expected.UnitsOut;
            }, "直接指定,GetAndSetValue");
            test1.Run(runTimes);

            var test2 = new TestInfo(() =>
            {
                var inventory = new FactProductInventory();
                foreach (var propertyName in s_propertyNames)
                {
                    var field = propertyName.Key;
                    var value = dynamicProperty.GetValue(expected, field);
                    dynamicProperty.SetValue(inventory, field, value);
                }
            }, "Expression反射,GetAndSetValue");
            test2.Run(runTimes);

            var test3 = new TestInfo(() =>
            {
                var inventory = new FactProductInventory();

                foreach (var propertyName in s_propertyNames)
                {
                    var field = propertyName.Key;
                    var value = reflectionProperty.GetValue(expected, field);
                    reflectionProperty.SetValue(inventory, field, value);
                }
            }, "Reflection反射,GetAndSetValue");
            test3.Run(runTimes);

            Assert.AreEqual(test1.RunCount, runTimes);
            Assert.AreEqual(test2.RunCount, runTimes);
            Assert.AreEqual(test3.RunCount, runTimes);
        }
    }

    public partial class FactProductInventory
    {
        public FactProductInventory()
        {
            ProductKey = 12;
            DateKey = 22;
            MovementDate = new DateTime(2015, 1, 1, 2, 1, 1, 3);
            UnitCost = 11.2m;
            UnitsIn = 5;
            UnitsOut = 3;
            UnitsBalance = 2;
        }

        public int ProductKey { get; set; }

        public int DateKey { get; set; }

        public DateTime MovementDate { get; set; }

        public decimal UnitCost { get; set; }

        public int UnitsIn { get; set; }

        public int UnitsOut { get; set; }

        public int UnitsBalance { get; set; }
    }
}