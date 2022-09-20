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

    public class ConnectionHelper
    {
        public string GetConnectionString(IConfiguration configuration)
        {
            string? connectionString = configuration.GetSection("pgSettings")["pgConnection"]; 
            string? databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            var finalString = string.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl);
            Program.ReferenceEquals(connectionString, finalString);
            return finalString;
        }
        
        //build the connection string from the environment. i.e. Heroku
        public string BuildConnectionString(string databaseUrl)
        {
            Uri databaseUri = new(databaseUrl);
            string[] userInfo = databaseUri.UserInfo.Split(':');
            NpgsqlConnectionStringBuilder builder = new()
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
