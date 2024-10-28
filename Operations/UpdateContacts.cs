using ContactManagementSystems.Validations;
using System;
using ContactManagementSystems;

namespace ContactManagementSystems.Views
{
    public class UpdateContacts
    {
        private readonly ContactContext _context;

        public UpdateContacts(ContactContext context)
        {
            _context = context;
        }

        public void UpdateContact()
        {
            while (true)
            {
                Console.Write("Enter Contact ID to update: ");

                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    try
                    {
                        var contact = _context.Contacts.Find(id);
                        if (contact == null)
                        {
                            Console.WriteLine("Contact not found. Please try again.");
                        }
                        else
                        {
                            Console.Write("Enter First Name (leave blank to keep current: {0}): ", contact.FirstName);
                            var firstName = Console.ReadLine();
                            if (!string.IsNullOrEmpty(firstName)) contact.FirstName = firstName;

                            Console.Write("Enter Last Name (leave blank to keep current: {0}): ", contact.LastName);
                            var lastName = Console.ReadLine();
                            if (!string.IsNullOrEmpty(lastName)) contact.LastName = lastName;

                            Console.Write("Enter Phone Number (leave blank to keep current: {0}): ", contact.PhoneNumber);
                            var phoneNumber = Console.ReadLine();
                            if (!string.IsNullOrEmpty(phoneNumber)) contact.PhoneNumber = phoneNumber;

                            Console.Write("Enter Email Address (leave blank to keep current: {0}): ", contact.Email);
                            var email = Console.ReadLine();
                            if (!string.IsNullOrEmpty(email)) contact.Email = email;

                            Console.Write("Enter Address (leave blank to keep current: {0}): ", contact.Address);
                            var address = Console.ReadLine();
                            if (!string.IsNullOrEmpty(address)) contact.Address = address;

                            
                            if (_context.Contacts.Any(c => c.PhoneNumber == contact.PhoneNumber && c.ID != contact.ID))
                            {
                                Console.WriteLine("Phone number already exists. Please enter a different phone number.");
                                Console.WriteLine("Press any key to re-enter the details...");
                                Console.ReadKey();
                                continue; 
                            }

                            if (_context.Contacts.Any(c => c.Email == contact.Email && c.ID != contact.ID))
                            {
                                Console.WriteLine("Email address already exists. Please enter a different email.");
                                Console.WriteLine("Press any key to re-enter the details...");
                                Console.ReadKey();
                                continue; 
                            }

                            if (!ContactValidator.ValidateContact(contact))
                            {
                                Console.WriteLine("Contact validation failed. Please check your input.");
                                Console.WriteLine("Press any key to re-enter the details...");
                                Console.ReadKey();
                            }
                            else
                            {
                                _context.SaveChanges();
                                Console.Clear();
                                Console.WriteLine("Contact updated successfully!");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID format. Please enter a numeric ID.");
                }

                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
                break;
            }
        }
    }
}
