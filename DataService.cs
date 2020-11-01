using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;


namespace fptRecruitingExercise
{
    public interface IDataService
    {
        Task<List<T>> QueryAsync<T>(string sql, object parameters = null);
        SqlConnection Connection();
        Task<List<Customer>> CustomerList(Pager pager);
    }


    public class DataService : IDataService
    {

        public DataService(Config config)
        {
            _connectionString = config.ConnectionString;
        }

        private readonly string _connectionString;
        private readonly int _defaultTimeout = Convert.ToInt32(TimeSpan.FromSeconds(60).TotalSeconds);

        public async Task<List<T>> QueryAsync<T>(string sql, object parameters = null)
        {
            return await ExecuteSql(parameters,
                async (cn, parms) => (await cn.QueryAsync<T>(sql, parms, commandTimeout: _defaultTimeout)).ToList());
        }

        public SqlConnection Connection()
        {
            var cn = new SqlConnection(_connectionString);
            if (cn.State != ConnectionState.Open) cn.Open();
            return cn;
        }

        private async Task<T> ExecuteSql<T>(object parameters, Func<SqlConnection, object, Task<T>> action)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                if (cn.State != ConnectionState.Open) cn.Open();
                return await action(cn, parameters);
            }
        }

        public async Task<List<Customer>> CustomerList(Pager pager)
        {
            var Query = @"

--DECLARE @Page INT= 1, @ItemsPerPage INT= 10;

SELECT Id, 
       Name, 
       Phone, 
       Email, 
       Notes,
        COUNT(1) OVER() AS TotalCount
FROM   dbo.Customer
ORDER BY name ASC
OFFSET(@Page - 1) * @ItemsPerPage ROWS FETCH NEXT @ItemsPerPage ROWS ONLY;
"; 
            return await QueryAsync<Customer>(Query, pager);
        }

    }
}
