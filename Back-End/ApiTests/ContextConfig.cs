using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace ApiTests
{
    public class ContextConfig
    {
         public static readonly NpgsqlDataSource DataSource;
        public static readonly string ClientAppBaseUrl = "http://localhost:5001";
        public static readonly string ApiBaseUrl = "http://localhost:5001/api";

        static ContextConfig()
        {
            var envVarKeyName = "pgconn";

            var rawConnectionString = Environment.GetEnvironmentVariable(envVarKeyName);
            if (string.IsNullOrEmpty(rawConnectionString))
            {
                throw new Exception("Environment variable 'pgconn' is not set. Write this in your powershell terminal: ' $env:pgconn='pgconn'");
            }

            try
            {
                var uri = new Uri(rawConnectionString);
                var properlyFormattedConnectionString = new NpgsqlConnectionStringBuilder
                {
                    Host = uri.Host,
                    Database = uri.AbsolutePath.Trim('/'),
                    Username = uri.UserInfo.Split(':')[0],
                    Password = uri.UserInfo.Split(':')[1],
                    Port = uri.Port > 0 ? uri.Port : 5432,
                    Pooling = false
                }.ToString();

                DataSource = new NpgsqlDataSourceBuilder(properlyFormattedConnectionString).Build();
                DataSource.OpenConnection().Close();
            }
            catch (Exception e)
            {
                throw new Exception("There is a problem with the pgconn connection string.", e);
            }
        }
    }
}