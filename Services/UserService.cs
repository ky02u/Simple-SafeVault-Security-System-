using MySqlConnector;

namespace SafeVault.Services
{
    public class UserService
    {
        private string connectionString =
            "server=localhost;database=SafeVault;user=root;password=1234";

        // Secure insert using parameterized query
        public void AddUser(string username, string email)
        {
            using var connection =
                new MySqlConnection(connectionString);

            string query =
                "INSERT INTO Users (Username, Email) VALUES (@Username, @Email)";

            using var command =
                new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Email", email);

            connection.Open();

            command.ExecuteNonQuery();
        }

        // Vulnerable example (for debugging demonstration)
        public string VulnerableSearchUser(string username)
        {
            string query =
                "SELECT * FROM Users WHERE Username = '" +
                username + "'";

            return query;
        }

        // Secure version using parameterized query
        public string SecureSearchUser()
        {
            string query =
                "SELECT * FROM Users WHERE Username = @Username";

            return query;
        }
    }
}