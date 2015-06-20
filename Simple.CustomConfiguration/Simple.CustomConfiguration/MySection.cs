using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Simple.CustomConfiguration
{
    public class MySection : ConfigurationSection
    {
        public static Configuration OpenExeAndLoadDefault()
        {
            //var config = ConfigurationManager.OpenMappedMachineConfiguration(new ConfigurationFileMap(targetXmlPath));
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            DefaultSettings(config);

            return config;
        }

        public static Configuration LoadFile(string targetXmlPath, bool isCreateDefault = false)
        {
            var config = ConfigurationManager.OpenMappedMachineConfiguration(new ConfigurationFileMap(targetXmlPath));
            if (isCreateDefault)
            {
                DefaultSettings(config);
            }
            return config;
        }

        private static void DefaultSettings(Configuration config)
        {
            var section = config.Sections["Section"];
            if (section == null)
            {
                MySection mySection = new MySection();
                mySection.Code = "9999";
                mySection.Member.Id = 100;
                mySection.Member.Name = "Sys";
                config.Sections.Add("Section", mySection);
            }

            var sectionGroup = config.SectionGroups["SectionGroup"];

            if (sectionGroup == null)
            {
                sectionGroup = new MySectionGroup();
                config.SectionGroups.Add("SectionGroup", sectionGroup);
                var mySection1 = new MySection() { Code = "1", Member = new MemberElement() { Id = 1, Name = "yao1" } };
                var mySection2 = new MySection() { Code = "2", Member = new MemberElement() { Id = 2, Name = "yao2" } };
                sectionGroup.Sections.Add("Section1", mySection1);
                sectionGroup.Sections.Add("Section2", mySection2);
            }
            config.Save(ConfigurationSaveMode.Minimal);
        }

        [ConfigurationProperty("Code", DefaultValue = "9527")]
        public string Code
        {
            get { return this["Code"].ToString(); }
            set { this["Code"] = value; }
        }

        [ConfigurationProperty("Member")]
        public MemberElement Member
        {
            get { return (MemberElement)this["Member"]; }
            set { this["Member"] = value; }
        }

        [ConfigurationProperty("Members"),
         ConfigurationCollection(typeof(MemberElement))]
        public MemberElementCollection Members
        {
            get { return this["Members"] as MemberElementCollection; }
            set { this["Members"] = value; }
        }
    }
}