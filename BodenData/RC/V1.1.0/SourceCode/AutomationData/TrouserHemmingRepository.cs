using System.Data.SqlClient;
using Dapper;

namespace AutomationData
{
    public class TrouserHemmingRepository
    {
        private readonly string _connectionString;

        public TrouserHemmingRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string GetProductCode()
        {
            string tierOneCode;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                tierOneCode = sqlConnection.ExecuteScalar<string>(@"SELECT TOP 1 Tier1 FROM [dbo].[ProductItemDetailsDenorm] WHERE [HemmingT1] <> ''");
            }

            return tierOneCode;
        }
    }
}