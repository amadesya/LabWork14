using Microsoft.Data.SqlClient;

namespace DBLibrary
{
    public static class DAL
    {
        private static string _server = @"PRSERVER\SQLEXPRESS";
        private static string _database = "ispp3512";
        private static string _login = "ispp3512";
        private static string _password = "3512";

        public static string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder builder = new()
                {
                    DataSource = _server,
                    InitialCatalog = _database,
                    UserID = _login,
                    Password = _password,
                    TrustServerCertificate = true
                };

                return builder.ConnectionString;
            }
        }

        public static async Task ChangeConnectionSettings(string server, string database, string login, string password)
        {
            _server = server;
            _database = database;
            _login = login;
            _password = password;
        }

        public static async Task<bool> CheckConnectivity()
        {
            try
            {
                using SqlConnection connection = new(ConnectionString);
                await connection.OpenAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<int> CompleteCommand(string query)
        {
            using SqlConnection connection = new(ConnectionString);
            await connection.OpenAsync();

            SqlCommand command = new(query, connection);
            return command.ExecuteNonQuery();
        }

        public static async Task<object?> GetObject(string query)
        {
            using SqlConnection connection = new(ConnectionString);
            await connection.OpenAsync();

            SqlCommand command = new(query, connection);
            return command.ExecuteScalarAsync();
        }
    }
}