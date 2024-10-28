using System.ComponentModel.DataAnnotations;
using System;

namespace ContactManagementSystems.Validations
{
    public static class ContactValidator
    {
        public static bool ValidateContact(Contact contact)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(contact);
            bool isValid = Validator.TryValidateObject(contact, validationContext, validationResults, true);

            if (!IsValidEmail(contact.Email))
            {
                Console.WriteLine("Invalid email format.");
                isValid = false;
            }

            if (!IsValidPhoneNumber(contact.PhoneNumber))
            {
                Console.WriteLine("Invalid phone number format.");
                isValid = false;
            }

            return isValid;
        }

        private static bool IsValidEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) && new EmailAddressAttribute().IsValid(email);
        }

        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$");
        }
    }
}