using NUnit.Framework;
using SafeVault.Services;

namespace SafeVault.Tests
{
    [TestFixture]
    public class TestAuthentication
    {
        private AuthService authService = null!;

        [SetUp]
        public void Setup()
        {
            authService = new AuthService();
        }

        [Test]
        public void ValidLoginShouldPass()
        {
            authService.Register(
                "admin",
                "SecurePassword123",
                "Admin"
            );

            bool result =
                authService.Login(
                    "admin",
                    "SecurePassword123"
                );

            Assert.That(result, Is.True);
        }

        [Test]
        public void InvalidLoginShouldFail()
        {
            authService.Register(
                "admin",
                "SecurePassword123",
                "Admin"
            );

            bool result =
                authService.Login(
                    "admin",
                    "WrongPassword"
                );

            Assert.That(result, Is.False);
        }
    }
}