using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.ORM.Performance
{
    public class DapperDAO : SqlFlowDataAccessBase, IFlowDataAccess
    {
        public int RowCount { get; set; }

        public object GetAllInventory()
        {
            var query = s_connection.Query<FactProductInventory>("SELECT * FROM FactProductInventory");
            this.RowCount = query.Count();
            return query;
        }
    }
}