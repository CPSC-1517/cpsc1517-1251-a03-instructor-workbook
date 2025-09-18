namespace Module01.HiringHelper
{
    using System.Text.RegularExpressions;

    public static class Utiliites
    {
        // If value is null/blank: throw ArgumentException(message). Return trimmed value otherwise.
        public static string RequireNotBlank(string? value, string message)
        {
            if (string.IsNullOrEmpty(value)) 
            { 
                throw new ArgumentException(message);
            }
            return value.Trim();
        }

        // If value is null/blank or doesn't match regex pattern: throw ArgumentException(message).
        public static string RequirePattern(string? value, string pattern, string message)
        {
            var notBlankValue = RequireNotBlank(value, message);
            if (!Regex.IsMatch(notBlankValue, pattern))
            {
                throw new ArgumentException(message);
            }
            return notBlankValue.Trim();
        }

        // If value < min or value > max: throw ArgumentOutOfRangeException(message). Return value otherwise.
        public static decimal RequireRange(decimal value, decimal min, decimal max, string message)
        {
            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(message);
            }
            return value;
        }

        // If value < min or value > max: throw ArgumentOutOfRangeException(message). Return value otherwise.
        public static double RequireRange(double value, double min, double max, string message)
        {
            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(message);
            }
            return value;
        }
    }
}
