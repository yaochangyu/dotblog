using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Transactions;

namespace Simple.ORM.BatchUpdate
{
    public class ZZZProject : IAccess
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
                    targetDbContext.FactProductInventories.AddRange(sources);
                    targetDbContext.BulkSaveChanges();
                    this.RowCount = sources.Count();
                }
                catch (Exception)
                {
                    throw;
                }
                return this.RowCount;
            }
        }

        public int Delete(int? rowCount = null)
        {
            using (var tranScope = new TransactionScope())
            using (var targetDbContext = new TargetDbContext())
            {
                targetDbContext.Configuration.AutoDetectChangesEnabled = false;
                targetDbContext.Configuration.ValidateOnSaveEnabled = false;
                targetDbContext.Configuration.LazyLoadingEnabled = false;
                targetDbContext.Configuration.ProxyCreationEnabled = false;

                List<FactProductInventory> targets;

                if (rowCount.HasValue)
                {
                    targets = targetDbContext.FactProductInventories
                        .OrderBy(o => o.ProductKey)
                        .Skip(0)
                        .Take(rowCount.Value)
                        .AsNoTracking()
                        .ToList();
                }
                else
                {
                    targets = targetDbContext.FactProductInventories
                        .AsNoTracking()
                        .ToList();
                }
                targetDbContext.BulkDelete(targets);
                tranScope.Complete();
                this.RowCount = targets.Count;
                return this.RowCount;
            }
        }

        public int Update(int? rowCount = null)
        {
            using (var targetDbContext = new TargetDbContext())
            {
                targetDbContext.Configuration.AutoDetectChangesEnabled = false;
                targetDbContext.Configuration.ValidateOnSaveEnabled = false;
                targetDbContext.Configuration.LazyLoadingEnabled = false;
                targetDbContext.Configuration.ProxyCreationEnabled = false;

                List<FactProductInventory> targets;

                if (rowCount.HasValue)
                {
                    targets = targetDbContext.FactProductInventories
                        .OrderBy(o => o.ProductKey)
                        .Skip(0)
                        .Take(rowCount.Value)
                        .AsNoTracking()
                        .ToList();
                }
                else
                {
                    targets = targetDbContext.FactProductInventories
                        .AsNoTracking()
                        .ToList();
                }

                foreach (var target in targets)
                {
                    target.UnitCost = 2.2m;
                    target.UnitsBalance = 888;
                    target.UnitsIn = 1;
                    target.UnitsOut = 1;
                    target.MovementDate = DateTime.Now;
                }

                targetDbContext.BulkUpdate(targets);
                this.RowCount = targets.Count;
                return this.RowCount;
            }
        }
    }
}