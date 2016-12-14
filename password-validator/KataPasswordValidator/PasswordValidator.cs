using System.Linq;

namespace KataPasswordValidator {
    public class PasswordValidator {
        private const int MinimunLength = 8;

        public bool Validate(string password) {
            if (!ValidateMinimunLength(password)) return false;
            if (!ContainsCapital(password)) return false;
            if (!ContainsLower(password)) return false;
            if (!ContainsNumber(password)) return false;
            if (!ContainsUnderscore(password)) return false;

            return true;
        }

        private bool ContainsUnderscore(string password) {
            return password.Contains("_");
        }

        private bool ContainsNumber(string password) {
            return password.Any(char.IsNumber);
        }

        private bool ContainsLower(string password) {
            return password.Any(char.IsLower);
        }

        private static bool ContainsCapital(string password) {
            return password.Any(char.IsUpper);
        }

        private static bool ValidateMinimunLength(string password) {
            return password.Length >= MinimunLength;
        }
    }
}
