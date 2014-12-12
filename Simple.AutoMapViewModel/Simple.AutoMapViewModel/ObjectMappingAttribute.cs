using System;

namespace Simple.AutoMapViewModel
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ObjectMappingAttribute : Attribute
    {
        public string PropertyName { get; set; }

        public ObjectMappingAttribute(string propertyName)
        {
            this.PropertyName = propertyName;
        }
    }
}