using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.CustomConfiguration
{
    public class MySection : ConfigurationSection
    {
        private MySection()
        {
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