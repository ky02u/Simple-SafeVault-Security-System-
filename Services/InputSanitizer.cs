using System.Text.RegularExpressions;
using System.Net;

namespace SafeVault.Services
{
    public class InputSanitizer
    {
        public string SanitizeInput(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            // Remove script tags
            input = Regex.Replace(
                input,
                "<script.*?</script>",
                "",
                RegexOptions.IgnoreCase
            );

            // Encode dangerous HTML
            input = WebUtility.HtmlEncode(input);

            // Remove dangerous SQL keywords
            input = Regex.Replace(
                input,
                @"\b(DROP|TABLE|DELETE|INSERT|UPDATE|SELECT|ALTER)\b",
                "",
                RegexOptions.IgnoreCase
            );

            // Remove dangerous characters
            input = input.Replace("'", "")
                         .Replace(";", "")
                         .Replace("--", "");

            return input.Trim();
        }
    }
}