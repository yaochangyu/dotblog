using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Simple.ORM.Performance
{
    public class DataReaderReflectMappingDAO : SqlFlowDataAccessBase, IFlowDataAccess
    {
        public int RowCount { get; set; }

        public object GetAllInventory()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM FactProductInventory", s_connection);

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

            var result = ReflectRowMapping(reader);

            this.RowCount = result.Count;
            return result;
        }

        private List<FactProductInventory> ReflectRowMapping(IDataReader reader)
        {
            List<FactProductInventory> inventoryList = new List<FactProductInventory>();
            var type = typeof(FactProductInventory);
            while (reader.Read())
            {
                FactProductInventory inventory = new FactProductInventory();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    var fieldName = reader.GetName(i);
                    var value = reader.GetValue(i);
                    PropertyInfo property = inventory.GetType().GetProperty(fieldName);
                    property.SetValue(inventory, reader.IsDBNull(i) ? "null" : value);
                }
                inventoryList.Add(inventory);
            }
            return inventoryList;
        }
    }
}