using NUnit.Framework;
using SafeVault.Services;

namespace SafeVault.Tests
{
    [TestFixture]
    public class TestSecurityFixes
    {
        private InputSanitizer sanitizer = null!;

        [SetUp]
        public void Setup()
        {
            sanitizer = new InputSanitizer();
        }

        [Test]
        public void SQLInjectionAttemptShouldBeBlocked()
        {
            string maliciousInput =
                "'; DROP TABLE Users; --";

            string result =
                sanitizer.SanitizeInput(maliciousInput);

            Assert.That(
                result.Contains("DROP"),
                Is.False
            );

            Assert.That(
                result.Contains("--"),
                Is.False
            );
        }

        [Test]
        public void XSSAttemptShouldBeBlocked()
        {
            string maliciousScript =
                "<script>alert('XSS')</script>";

            string result =
                sanitizer.SanitizeInput(maliciousScript);

            Assert.That(
                result.Contains("<script>"),
                Is.False
            );
        }

        [Test]
        public void DangerousSQLKeywordsShouldBeRemoved()
        {
            string input =
                "ALTER TABLE Users";

            string result =
                sanitizer.SanitizeInput(input);

            Assert.That(
                result.Contains("ALTER"),
                Is.False
            );
        }
    }
}