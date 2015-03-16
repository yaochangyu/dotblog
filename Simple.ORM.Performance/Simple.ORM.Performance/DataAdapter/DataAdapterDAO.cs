using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.ORM.Performance.DataAdapter
{
    public class DataAdapterDAO : SqlFlowDataAccessBase, IFlowDataAccess
    {
        public int RowCount { get; set; }

        public object GetAllInventory()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM FactProductInventory", s_connection);

            DataTable tableReader = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tableReader);
            this.RowCount = tableReader.Rows.Count;
            return tableReader;
        }
    }
}