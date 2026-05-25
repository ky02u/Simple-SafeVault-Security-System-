using NUnit.Framework;
using SafeVault.Services;

namespace SafeVault.Tests
{
    [TestFixture]
    public class TestAuthorization
    {
        private AuthorizationService authorizationService = null!;

        [SetUp]
        public void Setup()
        {
            authorizationService =
                new AuthorizationService();
        }

        [Test]
        public void AdminShouldAccessDashboard()
        {
            bool result =
                authorizationService
                    .CanAccessAdminDashboard("Admin");

            Assert.That(result, Is.True);
        }

        [Test]
        public void UserShouldNotAccessDashboard()
        {
            bool result =
                authorizationService
                    .CanAccessAdminDashboard("User");

            Assert.That(result, Is.False);
        }
    }
}