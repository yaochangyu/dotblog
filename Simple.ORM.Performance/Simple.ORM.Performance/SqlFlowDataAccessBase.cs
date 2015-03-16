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
    public abstract class SqlFlowDataAccessBase
    {
        private static string s_connectString = ConfigurationManager.ConnectionStrings["AdventureWorksDW2012DbContext"].ConnectionString;
        protected static SqlConnection s_connection = null;
        private static bool s_disposed = false;

        static SqlFlowDataAccessBase()
        {
            s_connection = new SqlConnection(s_connectString);
            s_connection.Open();
        }

        ~SqlFlowDataAccessBase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (s_disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
                if (s_connection != null)
                {
                    if (s_connection.State == ConnectionState.Open)
                    {
                        s_connection.Close();
                    }
                    s_connection.Dispose();
                    s_connection = null;
                }
            }

            // Free any unmanaged objects here.
            //
            s_disposed = true;
        }
    }
}