using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace Simple.ORM.BatchUpdate
{
    public class EF6 : IAccess
    {
        public int RowCount { get; set; }

        public int Insert(int? rowCount = null)
        {
            using (var sourceDbContext = new SourceDbContext())
            using (var targetDbContext = new TargetDbContext())
            {
                targetDbContext.Configuration.AutoDetectChangesEnabled = false;
                targetDbContext.Configuration.ValidateOnSaveEnabled = false;
                targetDbContext.Configuration.LazyLoadingEnabled = false;
                targetDbContext.Configuration.ProxyCreationEnabled = false;
                List<FactProductInventory> sources;

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

                this.RowCount += SaveChanges(targetDbContext, sources, EntityState.Added);
                return this.RowCount;
            }
        }

        public int Delete(int? rowCount = null)
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

                this.RowCount = SaveChanges(targetDbContext, targets, EntityState.Deleted);
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

                //var random = new Random(Guid.NewGuid().GetHashCode());
                //var randomInts = new List<int>(Enumerable.Range(1, 1000));

                //foreach (var target in targets)
                //{
                //    var resultInts = randomInts.OrderBy(o => random.Next()).Take(3).ToList();
                //    target.UnitCost = (decimal)random.NextDouble();
                //    target.UnitsBalance = resultInts[0];
                //    target.UnitsIn = resultInts[1];
                //    target.UnitsOut = resultInts[2];
                //    target.MovementDate = DateTime.Now;
                //}

                foreach (var target in targets)
                {
                    target.UnitCost = 2.2m;
                    target.UnitsBalance = 888;
                    target.UnitsIn = 1;
                    target.UnitsOut = 1;
                    target.MovementDate = DateTime.Now;
                }

                foreach (var item in targets)
                {
                    targetDbContext.Entry(item).State = EntityState.Modified;
                }

                try
                {
                    //this.RowCount = targetDbContext.SaveChanges();
                    this.RowCount = SaveChanges(targetDbContext, targets, EntityState.Modified);
                }
                catch (Exception)
                {
                    throw;
                }

                return this.RowCount;
            }
        }

        private int SaveChanges(TargetDbContext targetDbContext, List<FactProductInventory> sources, EntityState state)
        {
            var baseCount = 100;
            var loopCount = sources.Count / baseCount;
            if (loopCount == 0)
            {
                loopCount++;
            }
            else if (sources.Count % loopCount != 0)
            {
                loopCount++;
            }

            var rowCount = 0;
            using (var beginTarn = targetDbContext.Database.BeginTransaction())
            {
                try
                {
                    for (int i = 0; i < loopCount; i++)
                    {
                        var targets = sources.Skip(i * baseCount).Take(baseCount);
                        foreach (var item in targets)
                        {
                            targetDbContext.Entry(item).State = state;
                        }
                        rowCount += targetDbContext.SaveChanges();
                    }
                    beginTarn.Commit();
                }
                catch (Exception)
                {
                    beginTarn.Rollback();
                    rowCount = 0;
                    throw;
                }
            }
            return rowCount;
        }

        private TargetDbContext BatchProcess(
            TargetDbContext context,
            FactProductInventory entity,
            int count,
            int commitCount,
            bool recreateContext)
        {
            context.Set<FactProductInventory>().Add(entity);

            if (count % commitCount == 0)
            {
                context.SaveChanges();
                if (recreateContext)
                {
                    context.Dispose();
                    context = new TargetDbContext();
                    context.Configuration.AutoDetectChangesEnabled = false;
                    context.Configuration.ValidateOnSaveEnabled = false;
                    context.Configuration.LazyLoadingEnabled = false;
                    context.Configuration.ProxyCreationEnabled = false;
                }
            }

            return context;
        }

        public static decimal NextDecimal(Random rng)
        {
            return new decimal(rng.Next(),
                               rng.Next(),
                               rng.Next(0x204FCE5E),
                               false,
                               0);
        }
    }
}