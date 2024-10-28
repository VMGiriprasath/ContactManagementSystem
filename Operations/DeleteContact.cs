using System;

public class DeleteContacts
{
    private readonly ContactContext _context;

    public DeleteContacts(ContactContext context)
    {
        _context = context;
    }

    public void DeleteContact()
    {
        while (true)
        {
            Console.Write("Enter Contact ID to delete: ");

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
                        _context.Contacts.Remove(contact);
                        _context.SaveChanges();
                        Console.Clear(); 
                        Console.WriteLine("Contact deleted successfully!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while trying to delete the contact: {ex.Message}");
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
