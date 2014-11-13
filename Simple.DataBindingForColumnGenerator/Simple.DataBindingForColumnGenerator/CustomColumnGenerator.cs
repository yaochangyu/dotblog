using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Simple.DataBindingForColumnGenerator
{
    public class CustomColumnGenerator<T> : IAutoFieldGenerator
    {
        private static PropertyInfo[] s_PropertyInfo;
        private List<BindingColumn> _columns = null;

        public CustomColumnGenerator()
        {
            if (s_PropertyInfo == null)
            {
                s_PropertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            }
            if (this._columns == null)
            {
                this._columns = new List<BindingColumn>();
            }
            foreach (var entityProperty in s_PropertyInfo)
            {
                var propertyName = entityProperty.Name;

                //找DisplayNameAttribute
                var attributeProperty =
                    entityProperty.GetCustomAttributes(typeof(DisplayNameAttribute), true).FirstOrDefault() as DisplayNameAttribute;

                var headerText = attributeProperty != null ?
                    attributeProperty.DisplayName :
                    propertyName;

                this._columns.Add(new BindingColumn()
                {
                    SortExpression = propertyName,
                    HeaderText = headerText,
                    DataField = propertyName
                });
            }
        }

        public ICollection GenerateFields(Control control)
        {
            return (from column in _columns
                    select new BoundField
                    {
                        SortExpression = column.SortExpression,
                        HeaderText = column.HeaderText,
                        DataField = column.DataField,
                    }).ToArray();
        }

        internal class BindingColumn
        {
            public string SortExpression { get; set; }

            public string HeaderText { get; set; }

            public string DataField { get; set; }
        }
    }
}