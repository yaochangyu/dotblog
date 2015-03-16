using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.ORM.Performance
{
    public class DataReaderLoadDataRowDAO : SqlFlowDataAccessBase, IFlowDataAccess
    {
        public int RowCount { get; set; }

        public object GetAllInventory()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM FactProductInventory", s_connection);

            DataTable tableReader = new DataTable();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

            for (int i = 0; i < reader.FieldCount; i++)
                tableReader.Columns.Add(reader.GetName(i), reader.GetFieldType(i));

            while (reader.Read())
            {
                object[] items = new object[reader.FieldCount];

                reader.GetValues(items);
                tableReader.LoadDataRow(items, true);
            }

            this.RowCount = tableReader.Rows.Count;
            return tableReader;
        }
    }
}