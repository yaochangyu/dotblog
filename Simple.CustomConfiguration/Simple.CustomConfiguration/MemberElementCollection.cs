using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.CustomConfiguration
{
    public class MemberElementCollection : ConfigurationElementCollection
    {
        public MemberElement this[int index]
        {
            get { return (MemberElement)this.BaseGet(index); }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new MemberElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MemberElement)element).Id;
        }
    }
}