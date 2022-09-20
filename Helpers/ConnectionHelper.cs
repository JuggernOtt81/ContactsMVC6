using ContactsMVC6;
using ContactsMVC6.Data;
using ContactsMVC6.Helpers;
using ContactsMVC6.Models;
using ContactsMVC6.Services;
using ContactsMVC6.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace ContactsMVC6.Helpers
{
    public static class ConnectionHelper
    {
        public static string GetConnectionString(string connectionString, string databaseUrl)
        {
            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            //var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            return string.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl);
        }
    
        //build the connection string from the environment. i.e. Heroku
        private static string BuildConnectionString(string databaseUrl)
        {
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };
            return builder.ToString();
        }
    }
}
