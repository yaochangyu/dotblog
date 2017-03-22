using System;
using System.Linq;
using System.Text;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace DevExpressEx
{
    public static class XtraGridExtension
    {
        private static readonly string[] ASC = {"asc", "ascending"};
        private static readonly string[] DESC = {"desc", "descending"};
        private static readonly string SYMBOL_SPACE = " ";

        public static string GetSortExpression(this GridView source,
                                               params string[] defaultFields)
        {
            string result = null;
            var sortExpression = GetSortExpression(source);
            if (!string.IsNullOrWhiteSpace(sortExpression))
            {
                return sortExpression;
            }

            //設定預設排序欄位
            var index = 0;
            var sortBuilder = new StringBuilder();

            foreach (var item in defaultFields)
            {
                ColumnSortOrder sortOrder;
                string fieldName;
                if (item.IndexOf(SYMBOL_SPACE) > 0)
                {
                    GetFieldAndSortOrder(item, out fieldName, out sortOrder);
                }
                else
                {
                    sortOrder = ColumnSortOrder.Descending;
                    fieldName = item;
                }
                index = GetSortBuilder(index, fieldName, sortOrder.ToString(), ref sortBuilder);
            }

            result = sortBuilder.ToString();
            return result;
        }

        public static string GetSortExpression(this GridView source)
        {
            string result = null;
            var sortBuilder = new StringBuilder();
            var sortSortInfos = source.SortInfo;
            var index = 0;

            foreach (var sortInfo in sortSortInfos.Cast<GridColumnSortInfo>())
            {
                var fieldName = sortInfo.Column.FieldName;
                var order = sortInfo.SortOrder.ToString();
                index = GetSortBuilder(index, fieldName, order, ref sortBuilder);
                index++;
            }

            result = sortBuilder.ToString();
            return result;
        }

        private static void GetFieldAndSortOrder(string source, out string fieldName, out ColumnSortOrder sortOrder)
        {
            var split = source.Split(new[] {SYMBOL_SPACE}, StringSplitOptions.RemoveEmptyEntries);
            fieldName = split[0];
            var sortCommand = split[1].ToLower();
            sortOrder = ColumnSortOrder.Descending;

            if (ASC.Any(p => p == sortCommand))
            {
                sortOrder = ColumnSortOrder.Ascending;
            }
            else if (DESC.Any(p => p == sortCommand))
            {
                sortOrder = ColumnSortOrder.Descending;
            }
        }

        private static int GetSortBuilder(int index, string fieldName, string order, ref StringBuilder sortBuilder)
        {
            if (index == 0)
            {
                sortBuilder.AppendFormat("{0} {1}", fieldName, order);
            }
            else
            {
                sortBuilder.AppendFormat(", {0} {1}", fieldName, order);
            }

            index++;
            return index;
        }
    }
}