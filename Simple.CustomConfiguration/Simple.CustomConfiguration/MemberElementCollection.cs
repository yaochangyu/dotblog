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
        //public MemberElement this[int index]
        //{
        //    get { return (MemberElement)BaseGet(index); }
        //    set
        //    {
        //        if (BaseGet(index) != null)
        //            BaseRemoveAt(index);
        //        BaseAdd(index, value);
        //    }
        //}

        //public void Add(MemberElement element)
        //{
        //    BaseAdd(element);
        //}

        //public void Clear()
        //{
        //    BaseClear();
        //}

        protected override ConfigurationElement CreateNewElement()
        {
            return new MemberElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MemberElement)element).Id;
        }

        //public void Remove(MemberElement element)
        //{
        //    BaseRemove(element.Id);
        //}

        //public void Remove(string name)
        //{
        //    BaseRemove(name);
        //}

        //public void RemoveAt(int index)
        //{
        //    BaseRemoveAt(index);
        //}
    }
}