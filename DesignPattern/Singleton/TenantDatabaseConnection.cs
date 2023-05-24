using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Singleton
{
    /// <summary>
    /// Singletone pattern -> MultiTenent  
    /// </summary>
    public class TenantDatabaseConnection
    {
        private static readonly Dictionary<string, TenantDatabaseConnection> instances = new Dictionary<string, TenantDatabaseConnection>();
        private static readonly object lockObject = new object();

        private readonly string connectionString;

        private TenantDatabaseConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public static TenantDatabaseConnection GetInstance(string tenantId, string connectionString)
        {
            if (!instances.ContainsKey(tenantId))
            {
                lock (lockObject)
                {
                    if (!instances.ContainsKey(tenantId))
                    {
                        instances[tenantId] = new TenantDatabaseConnection(connectionString);
                    }
                }
            }

            return instances[tenantId];
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }

}
