using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using MEC = Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
// There was a huge problem getting it to recognize _config.GetConnectionString(...)
// I tried a lot of things... and suddenly the problem went away. OK.

namespace DataAccessLibrary
{
    //internal class SqlDataAccess : ISqlDataAccess
    // public was the problem @34:00, but it went away and was needed gone for injection

    public class SqlDataAccess : ISqlDataAccess
    {
        //public readonly IConfiguration _config;
        //private readonly IConfiguration _config;
        //private readonly Microsoft.Extensions.Configuration.IConfiguration _config;
        private readonly MEC.IConfiguration _config;

        public string ConnectionStringName { get; set; } = "Default";

        // config will have to come from front end
        public SqlDataAccess(MEC.IConfiguration config) // config will ahve to come from front end
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(String sql, U parameters)
        {
            //string connectionString = _config.GetConnectionString(ConnectionStringName);
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);
                return data.ToList(); // ? Needs System.Linq;
            }
        }

        public async Task SaveData<T>(String sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
                // Task just sort of returns saying "complete".
            }
        }

    }
}
