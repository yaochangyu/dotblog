using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Simple.ORM.InsertBigRow
{
    public class BulkInsertEF6 : IAccess
    {
        public int RowCount { get; set; }

        public int Insert(int? rowCount = null)
        {
            using (SourceDbContext sourceDbContext = new SourceDbContext())
            using (TargetDbContext targetDbContext = new TargetDbContext())
            {
                targetDbContext.Configuration.AutoDetectChangesEnabled = false;
                targetDbContext.Configuration.ValidateOnSaveEnabled = false;
                targetDbContext.Configuration.LazyLoadingEnabled = false;
                targetDbContext.Configuration.ProxyCreationEnabled = false;

                IEnumerable<FactProductInventory> sources;
                if (rowCount.HasValue)
                {
                    sources = sourceDbContext.FactProductInventories
                        .OrderBy(o => o.ProductKey)
                        .Skip(0)
                        .Take(rowCount.Value)
                        .AsNoTracking()
                        .ToList();
                }
                else
                {
                    sources = sourceDbContext.FactProductInventories
                        .AsNoTracking()
                        .ToList();
                }
                try
                {
                    targetDbContext.BulkInsert(sources);

                    this.RowCount = sources.Count();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return this.RowCount;
        }

        public int Delete(int? count = null)
        {
            throw new NotImplementedException();
        }

        public int Update(int? rowCount = null)
        {
            throw new NotImplementedException();
        }
    }
}