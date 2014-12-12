using System;
using System.Linq;
using System.Reflection;

namespace Simple.AutoMapViewModel
{
    public class Utility
    {
        public TTarget Migration<TSource, TTarget>(TSource sourceInstance)
            where TSource : class,new()
        {
            var sourceType = sourceInstance.GetType();
            var targetType = typeof(TTarget);
            var sourceProperties = sourceType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var targetProperties = targetType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var targetInstance = Activator.CreateInstance<TTarget>();

            var mappingAttributeType = typeof(ObjectMappingAttribute);
            foreach (var sourceProperty in sourceProperties)
            {
                var sourcePropertyName = sourceProperty.Name;
                var sourceValue = sourceProperty.GetValue(sourceInstance);

                foreach (var targetProperty in targetProperties)
                {
                    var targetPropertyName = targetProperty.Name;
                    if (sourcePropertyName == targetPropertyName)
                    {
                        if (sourceProperty.PropertyType == targetProperty.PropertyType)
                        {
                            targetProperty.SetValue(targetInstance, sourceValue);
                            break;
                        }
                    }
                    var mappingAttributes = targetProperty.GetCustomAttributes(mappingAttributeType, false);
                    if (mappingAttributes.Any())
                    {
                        var mappingAttributePropertyName = ((ObjectMappingAttribute)mappingAttributes[0]).PropertyName;
                        if (mappingAttributePropertyName == sourcePropertyName)
                        {
                            if (sourceProperty.PropertyType == targetProperty.PropertyType)
                            {
                                targetProperty.SetValue(targetInstance, sourceValue);
                                break;
                            }
                        }

                    }

                }
            }
            return targetInstance;
        }
    }
}