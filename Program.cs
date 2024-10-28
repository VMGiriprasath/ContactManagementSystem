using ContactManagementSystems.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        using (var context = new ContactContext())
        {
          context.Database.EnsureCreated();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Contact Management System");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Update Contact");
                Console.WriteLine("3. View Contacts");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                var choice = Console.ReadLine();
                Console.WriteLine("");


                switch (choice)
                {
                    case "1":
                        AddContacts.AddContact(context);
                        break;
                    case "2":
                        var updateService = new UpdateContacts(context);
                        updateService.UpdateContact();
                        break;
                    case "3":
                        var viewService = new ViewContacts(context);
                        viewService.ViewContact();
                        break;
                    case "4":
                        var deleteService = new DeleteContacts(context);
                        deleteService.DeleteContact();
                        break;
                    case "5":
                        return;
                 
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
     
}
