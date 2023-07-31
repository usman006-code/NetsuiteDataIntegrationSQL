using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Data
{
    public class DbConnector: IDisposable
    {
        private SqlConnection connection1;
        private SqlConnection connection2;
        private SqlConnection connection3;

        public DbConnector(string connectionString1, string connectionString2,string connectionString3)
        {
            connection1 = new SqlConnection(connectionString1);
            connection2 = new SqlConnection(connectionString2);
            connection3 = new SqlConnection(connectionString3);
        }

        //Get more than one record
        private async Task<IEnumerable<T>> GetAllAsync<T>(string query, SqlConnection connection)
        {
            connection.Open();
            var results = await connection.QueryAsync<T>(query);
            connection.Close();
            return results;
        }
        //Get single record
        private async Task<T> GetSingleAsync<T>(string query, SqlConnection connection)
        {
            connection.Open();
            var result = await connection.QueryFirstOrDefaultAsync<T>(query);
            connection.Close();
            return result;
        }
        //Use to Insert, Delete and Update Database
        private async Task ExecuteQueryAsync(string query,SqlConnection connection)
        {
            connection.Open();
            await connection.ExecuteAsync(query);
            connection.Close();
        }





        public async Task<IEnumerable<T>> GetAllDataAsync<T>(string query, int connectStringNo = 1)
        {
            try
            {
                if (connectStringNo == 1)
                    return await GetAllAsync<T>(query, connection1);
                else if (connectStringNo == 2)
                    return await GetAllAsync<T>(query, connection2);
                else
                    return await GetAllAsync<T>(query, connection3);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> GetSingleDataAsync<T>(string query,int connectStringNo = 1)
        {
            try
            {
                if (connectStringNo == 1)
                    return await GetSingleAsync<T>(query, connection1);
                else if (connectStringNo == 2)
                    return await GetSingleAsync<T>(query, connection2);
                else
                    return await GetSingleAsync<T>(query, connection3);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ExecuteQueryDataAsync(string query, int connectStringNo = 1)
        {
            try
            {
                if (connectStringNo == 1)
                    await ExecuteQueryAsync(query, connection1);
                else if (connectStringNo == 2)
                    await ExecuteQueryAsync(query, connection2);
                else
                    await ExecuteQueryAsync(query, connection3);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            if (connection1 != null)
            {
                connection1.Dispose();
                connection1 = null;
            }
            if (connection2 != null)
            {
                connection2.Dispose();
                connection2 = null;
            }
        }
    }
}
