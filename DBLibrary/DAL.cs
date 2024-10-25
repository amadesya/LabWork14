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

        public static async Task ChangeConnectionSettings(string _server, string _database, string _login, string _password)
        {
            using SqlConnection connection = new(ConnectionString);
            await connection.OpenAsync();
        }
    }
}