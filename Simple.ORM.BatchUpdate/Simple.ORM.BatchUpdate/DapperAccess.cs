using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.ORM.BatchUpdate
{
    public class DapperAccess : IAccess
    {
        public int RowCount { get; set; }

        public int Insert(int? rowCount = null)
        {
            var sourceConnectString = ConfigurationManager.ConnectionStrings["sourceDbContext"].ConnectionString;
            var targetConnectString = ConfigurationManager.ConnectionStrings["TargetDbContext"].ConnectionString;
            using (var sourceConnect = new SqlConnection(sourceConnectString))
            using (var targetConnect = new SqlConnection(targetConnectString))
            {
                sourceConnect.Open();
                targetConnect.Open();

                string queryString = "";
                if (rowCount.HasValue)
                {
                    queryString = string.Format(@"SELECT
    [Extent1].[ProductKey] AS [ProductKey],
    [Extent1].[DateKey] AS [DateKey],
    [Extent1].[MovementDate] AS [MovementDate],
    [Extent1].[UnitCost] AS [UnitCost],
    [Extent1].[UnitsIn] AS [UnitsIn],
    [Extent1].[UnitsOut] AS [UnitsOut],
    [Extent1].[UnitsBalance] AS [UnitsBalance]
    FROM [dbo].[FactProductInventory] AS [Extent1]
    ORDER BY [Extent1].[ProductKey] ASC
    OFFSET 0 ROWS FETCH NEXT {0} ROWS ONLY
", rowCount.Value);
                }
                else
                {
                    queryString = @"SELECT
    [Extent1].[ProductKey] AS [ProductKey],
    [Extent1].[DateKey] AS [DateKey],
    [Extent1].[MovementDate] AS [MovementDate],
    [Extent1].[UnitCost] AS [UnitCost],
    [Extent1].[UnitsIn] AS [UnitsIn],
    [Extent1].[UnitsOut] AS [UnitsOut],
    [Extent1].[UnitsBalance] AS [UnitsBalance]
    FROM [dbo].[FactProductInventory]
";
                }

                var sources = sourceConnect.Query<FactProductInventory>(queryString);
                StringBuilder updateString = new StringBuilder();
                foreach (var item in sources)
                {
                    var sql = string.Format(@"exec sp_executesql N'INSERT [dbo].[FactProductInventory]([ProductKey], [DateKey], [MovementDate], [UnitCost], [UnitsIn], [UnitsOut], [UnitsBalance])
VALUES (@0, @1, @2, @3, @4, @5, @6)
',N'@0 int,@1 int,@2 datetime2(7),@3 decimal(19,4),@4 int,@5 int,@6 int',@0={0},@1={1},@2='{2}',@3={3},@4={4},@5={5},@6={6}",
                    item.ProductKey,
                    item.DateKey,
                    item.MovementDate.ToString("yyyy-MM-dd hh:mm:ss.ffff"),
                    item.UnitCost,
                    item.UnitsIn,
                    item.UnitsOut,
                    item.UnitsBalance
                    );
                    updateString.AppendLine(sql);
                }
                this.RowCount = targetConnect.Execute(updateString.ToString());
            }
            return RowCount;
        }

        public int Delete(int? rowCount = null)
        {
            var targetConnectString = ConfigurationManager.ConnectionStrings["TargetDbContext"].ConnectionString;
            using (var targetConnect = new SqlConnection(targetConnectString))
            {
                targetConnect.Open();

                string queryString = "";
                if (rowCount.HasValue)
                {
                    queryString = string.Format(@"SELECT
    [Extent1].[ProductKey] AS [ProductKey],
    [Extent1].[DateKey] AS [DateKey],
    [Extent1].[MovementDate] AS [MovementDate],
    [Extent1].[UnitCost] AS [UnitCost],
    [Extent1].[UnitsIn] AS [UnitsIn],
    [Extent1].[UnitsOut] AS [UnitsOut],
    [Extent1].[UnitsBalance] AS [UnitsBalance]
    FROM [dbo].[FactProductInventory] AS [Extent1]
    ORDER BY [Extent1].[ProductKey] ASC
    OFFSET 0 ROWS FETCH NEXT {0} ROWS ONLY
", rowCount.Value);
                }
                else
                {
                    queryString = @"SELECT
    [Extent1].[ProductKey] AS [ProductKey],
    [Extent1].[DateKey] AS [DateKey],
    [Extent1].[MovementDate] AS [MovementDate],
    [Extent1].[UnitCost] AS [UnitCost],
    [Extent1].[UnitsIn] AS [UnitsIn],
    [Extent1].[UnitsOut] AS [UnitsOut],
    [Extent1].[UnitsBalance] AS [UnitsBalance]
    FROM [dbo].[FactProductInventory]
";
                }

                var readers = targetConnect.Query<FactProductInventory>(queryString);
                StringBuilder updateString = new StringBuilder();
                foreach (var item in readers)
                {
                    var sql = string.Format(@"exec sp_executesql N'DELETE [dbo].[FactProductInventory]
WHERE (([ProductKey] = @0) AND ([DateKey] = @1))',N'@0 int,@1 int',@0={0},@1={1}", item.ProductKey, item.DateKey);
                    updateString.AppendLine(sql);
                }
                this.RowCount = targetConnect.Execute(updateString.ToString());
            }
            return RowCount;
        }

        public int Update(int? rowCount = null)
        {
            var targetConnectString = ConfigurationManager.ConnectionStrings["TargetDbContext"].ConnectionString;
            using (var targetConnect = new SqlConnection(targetConnectString))
            {
                targetConnect.Open();

                string queryString = "";
                if (rowCount.HasValue)
                {
                    queryString = string.Format(@"SELECT
    [Extent1].[ProductKey] AS [ProductKey],
    [Extent1].[DateKey] AS [DateKey],
    [Extent1].[MovementDate] AS [MovementDate],
    [Extent1].[UnitCost] AS [UnitCost],
    [Extent1].[UnitsIn] AS [UnitsIn],
    [Extent1].[UnitsOut] AS [UnitsOut],
    [Extent1].[UnitsBalance] AS [UnitsBalance]
    FROM [dbo].[FactProductInventory] AS [Extent1]
    ORDER BY [Extent1].[ProductKey] ASC
    OFFSET 0 ROWS FETCH NEXT {0} ROWS ONLY
", rowCount.Value);
                }
                else
                {
                    queryString = @"SELECT
    [Extent1].[ProductKey] AS [ProductKey],
    [Extent1].[DateKey] AS [DateKey],
    [Extent1].[MovementDate] AS [MovementDate],
    [Extent1].[UnitCost] AS [UnitCost],
    [Extent1].[UnitsIn] AS [UnitsIn],
    [Extent1].[UnitsOut] AS [UnitsOut],
    [Extent1].[UnitsBalance] AS [UnitsBalance]
    FROM [dbo].[FactProductInventory]
";
                }

                var readers = targetConnect.Query<FactProductInventory>(queryString);
                StringBuilder updateString = new StringBuilder();
                foreach (var item in readers)
                {
                    var sql = string.Format(@"exec sp_executesql N'UPDATE [dbo].[FactProductInventory]
SET [MovementDate] = @0, [UnitCost] = @1, [UnitsIn] = @2, [UnitsOut] = @3, [UnitsBalance] = @4
WHERE (([ProductKey] = @5) AND ([DateKey] = @6))
',N'@0 datetime2(7),@1 decimal(19,4),@2 int,@3 int,@4 int,@5 int,@6 int',@0='{0}',@1={1},@2={2},@3={3},@4={4},@5={5},@6={6}"
                        , DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.ffff")
                        , 2.22m
                        , 888
                        , 1
                        , 1
                        , item.ProductKey
                        , item.DateKey
                        );
                    updateString.AppendLine(sql);
                }
                this.RowCount = targetConnect.Execute(updateString.ToString());
            }
            return RowCount;
        }
    }
}