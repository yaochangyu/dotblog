using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.ORM.Performance.EF
{
    public class EntityDAO : IFlowDataAccess
    {
        public int RowCount { get; set; }

        public object GetAllInventory()
        {
            using (AdventureWorksDbContext db = new AdventureWorksDbContext())
            {
                var query = db.FactProductInventories.ToList();
                this.RowCount = query.Count();
                return query;
            }
        }
    }
}