using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Newtonsoft.Json;

namespace Simple.DeepClone2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void 物件複製_0_錯誤的做法()
        {
            var source = new Person();
            source.Address = "地球村";
            source.Age = 18;
            source.Name = new Name("余", "小章");

            var target = source;

            //改變狀態
            target.Age = 20;
            target.Address = "火星";
            target.Name.FirstName = "張";

            //source欄位的狀態都被改變了，因為仍然是參考同一份記憶體位置
            Assert.AreNotEqual(source.Age, 18);
            Assert.AreNotEqual(source.Address, "地球村");
            Assert.AreNotEqual(source.Name.FirstName, "余");
        }

        [TestMethod]
        public void 物件複製_1_淺複製_MemberwiseClone()
        {
            var source = new Person();
            source.Address = "地球村";
            source.Age = 18;
            source.Name = new Name("余", "小章");

            var target = source.Clone();

            //改變狀態
            target.Age = 20;
            target.Address = "火星";
            target.Name.FirstName = "張";

            //淺複製會複製實質型別的狀態，參考型別複製記憶體位置
            Assert.AreEqual(source.Age, 18);
            Assert.AreEqual(source.Address, "地球村");
            Assert.AreNotEqual(source.Name.FirstName, "余");
        }

        [TestMethod]
        public void 物件複製_2_深複製_手工復刻()
        {
            var source = new Person();
            source.Address = "地球村";
            source.Age = 18;
            source.Name = new Name("余", "小章");
            Person target = null;

            target = new Person();
            target.Address = source.Address;
            target.Age = source.Age;
            target.Name = new Name(source.Name.FirstName, source.Name.LastName);

            //改變狀態
            target.Age = 20;
            target.Address = "火星";
            target.Name.FirstName = "張";

            Assert.AreEqual(source.Age, 18);
            Assert.AreEqual(source.Address, "地球村");
            Assert.AreEqual(source.Name.FirstName, "余");
        }

        [TestMethod]
        public void 物件複製_3_深複製_序列化()
        {
            var source = new Person();
            source.Address = "地球村";
            source.Age = 18;
            source.Name = new Name("余", "小章");

            Person target = null;

            //熱機
            target = JsonConvert.DeserializeObject<Person>(JsonConvert.SerializeObject(source));
          

            //改變狀態
            target.Age = 20;
            target.Address = "火星";
            target.Name.FirstName = "張";

            Assert.AreEqual(source.Age, 18);
            Assert.AreEqual(source.Address, "地球村");
            Assert.AreEqual(source.Name.FirstName, "余");
        }

        [TestMethod]
        public void 物件複製_4_深複製_反射()
        {
            var source = new Person();
            source.Address = "地球村";
            source.Age = 18;
            source.Name = new Name("余", "小章");
            Person personTarget = null;

            for (int i = 0; i < 100000; i++)
            {
                var personType = typeof(Person);
                var personPropertyInfos =
                    personType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                personTarget = Activator.CreateInstance<Person>();

                foreach (var personPropertyInfo in personPropertyInfos)
                {
                    var personValue = personPropertyInfo.GetValue(source, null);
                    if (personPropertyInfo.PropertyType == typeof(Name))
                    {
                        var nameType = typeof(Name);
                        var namePropertyInfos =
                            nameType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                        personTarget.Name = Activator.CreateInstance<Name>();
                        foreach (var namePropertyInfo in namePropertyInfos)
                        {
                            var nameValue = namePropertyInfo.GetValue(source.Name, null);
                            namePropertyInfo.SetValue(personTarget.Name, nameValue, null);
                        }
                    }
                    else
                    {
                        personPropertyInfo.SetValue(personTarget, personValue, null);
                    }
                }
            }

            //改變狀態
            personTarget.Age = 20;
            personTarget.Address = "火星";
            personTarget.Name.FirstName = "張";

            Assert.AreEqual(source.Age, 18);
            Assert.AreEqual(source.Address, "地球村");
            Assert.AreEqual(source.Name.FirstName, "余");
        }

        [TestMethod]
        public void 物件複製_5_深複製_AutoMapper()
        {
            var source = new Person();
            source.Address = "地球村";
            source.Age = 18;
            source.Name = new Name("余", "小章");
          
            var config = new MapperConfiguration(cfg =>
                                                 {
                                                     cfg.CreateMap<Person, Person>();
                                                     cfg.CreateMap<Name, Name>();
                                                 });
            var mapper = config.CreateMapper();
            Person target = null;
            target = new Person();

            //熱機
            target = new Person();
            mapper.Map(source, target);

            //改變狀態
            target.Age = 20;
            target.Address = "火星";
            target.Name.FirstName = "張";

            Assert.AreEqual(source.Age, 18);
            Assert.AreEqual(source.Address, "地球村");
            Assert.AreEqual(source.Name.FirstName, "余");
        }

    }
}