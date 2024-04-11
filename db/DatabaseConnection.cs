using Npgsql;

namespace ElephantSQL.db
{
    public class DatabaseConnection
    {
        private readonly string _connectionString;

        public DatabaseConnection(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<NpgsqlConnection> GetConnectionAsync()
        {
            var connection = new NpgsqlConnection(_connectionString);
            try
            {
                await connection.OpenAsync();
                return connection;
            }
            catch (NpgsqlException ex)
            {
                // Specific handling for Npgsql exceptions
                connection.Dispose(); // Ensure the connection is disposed in case of an error
                throw new Exception("Failed to connect to the PostgreSQL database", ex);
            }
            catch (Exception ex)
            {
                // General exception handling
                connection.Dispose(); // Ensure the connection is disposed in case of an error
                throw new Exception("An error occurred while establishing a database connection", ex);
            }
        }
    }
}
