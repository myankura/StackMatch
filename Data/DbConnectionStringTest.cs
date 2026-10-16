using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace StackMatch.Data
{
    public sealed record ConnectionTestResult(bool Success, string? ErrorMessage = null, Exception? Exception = null);

    public static class DbConnectionStringTest
    {
        /// <summary>
        /// Tests the provided connection string by opening a connection and executing a lightweight query (SELECT 1).
        /// Returns a structured result rather than throwing so callers can log or react accordingly.
        /// </summary>
        public static async Task<ConnectionTestResult> TestAsync(string? connectionString, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return new ConnectionTestResult(false, "Connection string is null or empty");
            }

            try
            {
                await using var conn = new SqlConnection(connectionString);
                // Open the connection (honors the provided cancellation token)
                await conn.OpenAsync(cancellationToken);

                // Execute a tiny command to verify we can run SQL against the server
                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT 1";
                cmd.CommandTimeout = 5; // short timeout for quick feedback
                await cmd.ExecuteScalarAsync(cancellationToken);

                return new ConnectionTestResult(true);
            }
            catch (Exception ex)
            {
                return new ConnectionTestResult(false, "DbConnectionStringTest - TestAsync - Failed to verify connection using the provided connection string");
            }
        }
    }
}
        