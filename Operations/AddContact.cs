using System;
using ContactManagementSystems.Validations;

namespace ContactManagementSystems.Views
{
    public class AddContacts
    {
        public static void AddContact(ContactContext context)
        {
            while (true)
            {
                var contact = new Contact();

                Console.WriteLine("Enter Contact Details");

                Console.Write("Enter First Name: ");
                contact.FirstName = Console.ReadLine();

                Console.Write("Enter Last Name: ");
                contact.LastName = Console.ReadLine();

                Console.Write("Enter Phone Number: ");
                contact.PhoneNumber = Console.ReadLine();

                Console.Write("Enter Email Address: ");
                contact.Email = Console.ReadLine();

                Console.Write("Enter Address: ");
                contact.Address = Console.ReadLine();

                if (context.Contacts.Any(c => c.PhoneNumber == contact.PhoneNumber))
                {
                    Console.WriteLine("Phone number already exists. Please enter a different phone number.");
                    Console.WriteLine("Press any key to re-enter the details...");
                    Console.ReadKey();
                    continue; 
                }

                if (context.Contacts.Any(c => c.Email == contact.Email))
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
                    context.Contacts.Add(contact);
                    context.SaveChanges();
                    Console.Clear();
                    Console.WriteLine("Contact added successfully!");
                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
