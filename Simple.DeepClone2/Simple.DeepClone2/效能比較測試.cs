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
    public class 效能比較測試
    {
        [TestMethod]
        public void 跑吧()
        {
            this.Run(1);
            this.Run(10);
            this.Run(100);
            this.Run(1000);
            this.Run(10000);
            this.Run(100000);
            this.Run(1000000);
            this.Run(10000000);
            this.Run(100000000);
        }

        private Person CloneByAutoMapper(Person source, IMapper mapper)
        {
            var target = new Person();
            mapper.Map(source, target);
            return target;
        }

        private Person CloneByHardCode(Person source)
        {
            Person target;
            target = new Person();
            target.Address = source.Address;
            target.Age = source.Age;
            target.Name = new Name(source.Name.FirstName, source.Name.LastName);
            return target;
        }

        private Person CloneByJsonNET(Person source)
        {
            Person target = null;

            //熱機
            target = JsonConvert.DeserializeObject<Person>(JsonConvert.SerializeObject(source));
            return target;
        }

        private Person CloneByReflection(Person source)
        {
            Person personTarget = null;
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

            return personTarget;
        }

        private IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
                                                 {
                                                     cfg.CreateMap<Person, Person>();
                                                     cfg.CreateMap<Name, Name>();
                                                 });
            var mapper = config.CreateMapper();
            return mapper;
        }

        private Person CreateSource()
        {
            var source = new Person();
            source.Address = "地球村";
            source.Age = 18;
            source.Name = new Name("余", "小章");
            return source;
        }

        private void ProcessTime(Action action, int runCount, [CallerMemberName] string methodName = "")
        {
            var watch = new Stopwatch();
            watch.Start();

            for (var i = 0; i < runCount; i++)
            {
                action.Invoke();
            }

            watch.Stop();
            var msg = $"測試方法:{methodName},花費時間:{watch.Elapsed.TotalMilliseconds}ms";
            Trace.WriteLine(msg);
        }

        private void Run(int count)
        {
            var source = this.CreateSource();
            var mapper = this.CreateMapper();

            //熱機
            this.CloneByHardCode(source);
            this.CloneByJsonNET(source);
            this.CloneByReflection(source);
            this.CloneByAutoMapper(source, mapper);

            Trace.WriteLine("行執次數:" + count);
            this.ProcessTime(() => this.CloneByHardCode(source), count, "Hard Code".PadRight(20, ' '));
            this.ProcessTime(() => this.CloneByJsonNET(source), count, "JSON.NET".PadRight(20, ' '));
            this.ProcessTime(() => this.CloneByReflection(source), count, "Reflection".PadRight(20, ' '));
            this.ProcessTime(() => this.CloneByAutoMapper(source, mapper), count, "AutoMapper".PadRight(20, ' '));
            Trace.WriteLine("");
        }
    }
}