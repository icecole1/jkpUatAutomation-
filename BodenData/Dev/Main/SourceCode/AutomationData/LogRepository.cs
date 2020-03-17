using System;
using System.Data.SqlClient;
using Dapper;

namespace AutomationData
{
    public class LogRepository
    {
        private readonly string _platform;
        private readonly string _market;
        private readonly string _connectionString;

        public LogRepository(string platform, string market, string connectionString)
        {
            _platform = platform;
            _market = market;
            _connectionString = connectionString;
        }

        public void Log(string screenShot, string message)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Execute($@"INSERT INTO [BodenAutomation].[dbo].[log] ([error], [datetime], [computer], [screenshot], [platform], [market]) VALUES (
                    '{message}', 
                    '{DateTime.Now}', 
                    '{Environment.MachineName}', 
                    '{screenShot}', 
                    '{_platform}', 
                    '{_market}')
                ");
            }
        }
    }
}