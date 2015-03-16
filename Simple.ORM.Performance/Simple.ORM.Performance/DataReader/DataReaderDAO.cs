using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.ORM.Performance
{
    public class DataReaderDAO : SqlFlowDataAccessBase, IFlowDataAccess
    {
        public int RowCount { get; set; }

        public object GetAllInventory()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM FactProductInventory", s_connection);

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

            int count = 0;
            while (reader.Read())
            {
                object[] items = new object[reader.FieldCount];

                reader.GetValues(items);
                count++;
            }

            this.RowCount = count;
            return reader;
        }
    }
}