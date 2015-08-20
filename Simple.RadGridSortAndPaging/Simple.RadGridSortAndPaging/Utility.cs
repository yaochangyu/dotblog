using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Web;
using Simple.RadGridSortAndPaging.Extensions;
using Telerik.Web.UI;

namespace Simple.RadGridSortAndPaging
{
    public class Utility
    {
        private static Dictionary<Type, PropertyInfo[]> s_PropertyInfoContainer;
        public Utility()
        {
            if (s_PropertyInfoContainer == null)
            {
                s_PropertyInfoContainer = new Dictionary<Type, PropertyInfo[]>();
            }
        }

        private PropertyInfo[] getPropertyInfos(Type targetType)
        {
            PropertyInfo[] targetPropertyInfos;
            if (!s_PropertyInfoContainer.ContainsKey(targetType))
            {
                var flag = BindingFlags.Instance | BindingFlags.Public;
                targetPropertyInfos = targetType.GetProperties(flag);
                s_PropertyInfoContainer.Add(targetType, targetPropertyInfos);
            }
            else
            {
                targetPropertyInfos = s_PropertyInfoContainer[targetType];
            }
            return targetPropertyInfos;
        }

        public TTarget CreateInstance<TTarget>(GridEditableItem sourceDataItem)
        {
            var targetType = typeof(TTarget);
            PropertyInfo[] targetPropertyInfos = getPropertyInfos(targetType);

            var sourceTable = new Hashtable();
            sourceDataItem.OwnerTableView.ExtractValuesFromItem(sourceTable, sourceDataItem);

            var targetInstance = Activator.CreateInstance<TTarget>();


            foreach (DictionaryEntry source in sourceTable)
            {
                var sourceColumnName = source.Key.ToString();
                var sourceValue = source.Value;
                if (sourceValue == null)
                {
                    continue;
                }
                foreach (var targetProperty in targetPropertyInfos)
                {
                    var targetColumnName = targetProperty.Name;
                    var targetPropertyType = targetProperty.PropertyType;

                    if (sourceColumnName == targetColumnName)
                    {
                        if (targetPropertyType.IsValueType)
                        {
                            object typeConverterResult = null;
                            if (IsNullable(targetPropertyType))
                            {
                                var innerType = Nullable.GetUnderlyingType(targetPropertyType);
                                typeConverterResult = GetTypeConverterResult(sourceValue, innerType);
                            }
                            else
                            {
                                typeConverterResult = GetTypeConverterResult(sourceValue, targetPropertyType);

                            }
                            targetProperty.SetValue(targetInstance, typeConverterResult, null);//Type Convert
                        }
                        else
                        {
                            targetProperty.SetValue(targetInstance, sourceValue);
                        }

                        break;
                    }
                }
            }

            return targetInstance;
        }

        public TTarget CreateInstance<TTarget>(Hashtable sources)
        {
            var targetType = typeof(TTarget);
            PropertyInfo[] targetPropertyInfos;
            if (!s_PropertyInfoContainer.ContainsKey(targetType))
            {
                var flag = BindingFlags.Instance | BindingFlags.Public;
                targetPropertyInfos = targetType.GetProperties(flag);
                s_PropertyInfoContainer.Add(targetType, targetPropertyInfos);
            }
            else
            {
                targetPropertyInfos = s_PropertyInfoContainer[targetType];
            }

            var targetInstance = Activator.CreateInstance<TTarget>();
            foreach (DictionaryEntry source in sources)
            {
                var sourceColumnName = source.Key.ToString();
                var sourceValue = source.Value;
                if (sourceValue == null)
                {
                    continue;
                }
                foreach (var targetProperty in targetPropertyInfos)
                {
                    var targetColumnName = targetProperty.Name;
                    var targetPropertyType = targetProperty.PropertyType;

                    if (sourceColumnName == targetColumnName)
                    {
                        if (targetPropertyType.IsValueType)
                        {
                            object typeConverterResult = null;
                            if (IsNullable(targetPropertyType))
                            {
                                var innerType = Nullable.GetUnderlyingType(targetPropertyType);
                                typeConverterResult = GetTypeConverterResult(sourceValue, innerType);
                            }
                            else
                            {
                                typeConverterResult = GetTypeConverterResult(sourceValue, targetPropertyType);

                            }
                            targetProperty.SetValue(targetInstance, typeConverterResult, null);//Type Convert
                        }
                        else
                        {
                            targetProperty.SetValue(targetInstance, sourceValue);
                        }

                        break;
                    }
                }
            }

            return targetInstance;
        }

        private object GetTypeConverterResult(object sourceValue, Type targetPropertyType)
        {
            ITypeConverter typeConverter = TypeConverterFactory.GetConvertType(targetPropertyType);
            object typeConverterResult;
            if (!targetPropertyType.IsEnum)
            {
                typeConverterResult = typeConverter.Convert(sourceValue);
            }
            else
            {
                EnumConverter converter = typeConverter as EnumConverter;
                typeConverterResult = converter.Convert(targetPropertyType, sourceValue);
            }
            return typeConverterResult;
        }

        private bool IsNullable(Type type)
        {
            return type.IsGenericType &&
                type.GetGenericTypeDefinition() == typeof(Nullable<>).GetGenericTypeDefinition(); ;
        }
    }
}