using DataIntegration.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Data.Repositories
{
    public class TestRepo
    {
        DbConnector connector;
        public TestRepo(string connectionString1)
        {
            connector = new DbConnector(connectionString1, connectionString1,connectionString1);
        }

        public async Task TestAsyncData()
        {
            string query = @"select * from gbltest";
            var obj = await connector.GetAllDataAsync<TestModel>(query);
            var obj2 = await connector.GetSingleDataAsync<TestModel>(query);
        }

    }
}
