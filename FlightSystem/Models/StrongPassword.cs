using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystemAPI.Models
{
    public class StrongPassword : ValidationAttribute
    {
        // Constructor to pass the error message to the base class
        public StrongPassword() : base("Password must be at least 8 characters long, contain one uppercase letter, one lowercase letter, one digit, and one special character.")
        {
        }

        // Overriding the IsValid method to define the custom validation logic
        public override bool IsValid(object value)
        {
            var password = value as string;

            // Check if the password is null or empty
            if (string.IsNullOrEmpty(password))
            {
                return false; // Invalid if password is empty or null
            }

            // Check if the password meets the criteria
            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasLowerCase = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecialChar = password.Any(ch => "!@#$%^&*()_+-=[]{}|;:,.<>?".Contains(ch));

            // The password must meet all these conditions
            return hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar && password.Length >= 8;
        }
    }
}
