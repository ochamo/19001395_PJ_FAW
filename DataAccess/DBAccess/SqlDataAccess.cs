using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.DBAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration config;

        public SqlDataAccess(IConfiguration config)
        {
            this.config = config;
        }

        public async Task DeleteSingle<P>(string sql, P parameters, string connectionId = "Default")
        {
            using MySqlConnection mySqlConnection = new MySqlConnection(connectionId);

            await mySqlConnection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<T>> LoadData<T, P>(string sql, P parameters, string connectionId = "Default")
        {
            using MySqlConnection connection = new MySqlConnection(config.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>(sql, parameters, commandType: CommandType.StoredProcedure);

        }

        public async Task SaveData<T>(string sql, T data, string connectionId = "Default")
        {
            using MySqlConnection connection = new MySqlConnection(config.GetConnectionString(connectionId));

            await connection.ExecuteAsync(sql, data, commandType: CommandType.StoredProcedure);

        }

        public async Task<T> Single<T, P>(string sql, P parameters, string connectionId = "Default")
        {
            using MySqlConnection connection = new MySqlConnection(config.GetConnectionString(connectionId));

            return await connection.QuerySingleAsync<T>(sql, parameters, commandType: CommandType.StoredProcedure);

        }
    }
}
