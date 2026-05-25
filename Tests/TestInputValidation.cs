using NUnit.Framework;
using SafeVault.Services;

namespace SafeVault.Tests
{
    [TestFixture]
    public class TestInputValidation
    {
        private InputSanitizer sanitizer;

        [SetUp]
        public void Setup()
        {
            sanitizer = new InputSanitizer();
        }

        [Test]
        public void TestForSQLInjection()
        {
            string maliciousInput = "'; DROP TABLE Users; --";

            string result = sanitizer.SanitizeInput(maliciousInput);

            Assert.False(result.Contains("DROP TABLE"));
            Assert.False(result.Contains("--"));
        }

        [Test]
        public void TestForXSS()
        {
            string maliciousScript =
                "<script>alert('XSS')</script>";

            string result = sanitizer.SanitizeInput(maliciousScript);

            Assert.False(result.Contains("<script>"));
        }
    }
}