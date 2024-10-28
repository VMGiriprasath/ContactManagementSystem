using System;
using System.Linq;

public class ViewContacts
{
    private readonly ContactContext _context;

    public ViewContacts(ContactContext context)
    {
        _context = context;
    }

    public void ViewContact()
    {
        var contacts = _context.Contacts.ToList();
        Console.WriteLine("Contacts:");

        Console.WriteLine($"{"ID",-10}{"First Name",-15}{"Last Name",-15}{"Phone Number",-15}{"Email Address",-25}{"Address",-30}");
        Console.WriteLine(new string('-', 120)); 
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{contact.ID,-10}{contact.FirstName,-15}{contact.LastName,-15}{contact.PhoneNumber,-15}{contact.Email,-25}{contact.Address,-30}");
        }

        Console.WriteLine(new string('-', 120));
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }
}
