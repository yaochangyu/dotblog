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
    public class DataReaderLoadDAO : SqlFlowDataAccessBase, IFlowDataAccess
    {
        public int RowCount { get; set; }

        public object GetAllInventory()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM FactProductInventory", s_connection);
            DataTable tableReader = new DataTable();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess);

            tableReader.Load(reader);

            this.RowCount = tableReader.Rows.Count;
            return tableReader;
        }
    }
}