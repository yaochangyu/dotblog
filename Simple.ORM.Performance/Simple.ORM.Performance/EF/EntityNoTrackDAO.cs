using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.ORM.Performance.EF
{
    public class EntityNoTrackDAO : IFlowDataAccess
    {
        public int RowCount { get; set; }

        public object GetAllInventory()
        {
            using (AdventureWorksDbContext db = new AdventureWorksDbContext())
            {
                var query = db.FactProductInventories.AsNoTracking().ToList();
                this.RowCount = query.Count();
                return query;
            }
        }
    }
}