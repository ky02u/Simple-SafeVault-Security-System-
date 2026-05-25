namespace SafeVault.Services
{
    public class AuthorizationService
    {
        public bool CanAccessAdminDashboard(string role)
        {
            return role == "Admin";
        }
    }
}