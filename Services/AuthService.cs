using BCrypt.Net;
using SafeVault.Models;

namespace SafeVault.Services
{
    public class AuthService
    {
        private List<User> users = new List<User>();

        public void Register(string username, string password, string role)
        {
            string hashedPassword =
                BCrypt.Net.BCrypt.HashPassword(password);

            users.Add(new User
            {
                Username = username,
                PasswordHash = hashedPassword,
                Role = role
            });
        }

        public bool Login(string username, string password)
        {
            var user =
                users.FirstOrDefault(u => u.Username == username);

            if (user == null)
                return false;

            return BCrypt.Net.BCrypt.Verify(
                password,
                user.PasswordHash
            );
        }

        public string GetUserRole(string username)
        {
            var user =
                users.FirstOrDefault(u => u.Username == username);

            return user?.Role ?? "";
        }
    }
}