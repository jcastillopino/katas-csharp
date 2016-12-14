using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace KataPasswordValidator {
    public class PasswordValidator {
        private const int MinimunLength = 8;

        public bool IsValid(string password) {
            if (!ValidateMinimunLength(password)) return false;
            if (!ContainsCapital(password)) return false;
            if (!ContainsLower(password)) return false;
            if (!ContainsNumber(password)) return false;
            if (!ContainsUnderscore(password)) return false;

            return true;
        }

        private static bool ContainsNumber(string password) {
            return password.Any(char.IsNumber);
            //return password.HasNumber();
        }

        private static bool ContainsCapital(string password) {
            return password.Any(char.IsUpper);
            //return password.HasCapital();
        }

        private static bool ContainsUnderscore(string password) {
            return password.Contains("_");
        }

        private static bool ContainsLower(string password) {
            return password.Any(char.IsLower);
        }

        private static bool ValidateMinimunLength(string password) {
            return password.Length >= MinimunLength;
        }
    }

    //public static class StringExtension {
    //    public static bool HasCapital(this string value) {
    //        return value.Any(char.IsUpper);
    //    }

    //    public static bool HasNumber(this string value) {
    //        return value.Any(char.IsNumber);
    //    }
    //}
}
