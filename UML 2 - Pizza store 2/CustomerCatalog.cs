using System;
using System.Collections.Generic;
using System.Text;

namespace UML_2___Pizza_Store_2
{
    public class CustomerCatalog
    {
        public static List<Customer> _listOfCustomers;

        public CustomerCatalog()
        {
            _listOfCustomers = new List<Customer>();
        }

        public static List<Customer> ListOfCustomers { get { return _listOfCustomers; } }

        public static void MenuForCustomers()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("THE CUSTOMER MENU");
            Console.ResetColor();
            int choice = InputFromUser.ChoicesOfMenu("Customer");
            if (choice == 1) CreatingACustomer();
            if (_listOfCustomers.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are no customers.");
                Console.ResetColor();
                MenuCatalog.TheMenu();
            }
            if (choice == 1) CreatingACustomer();
            if (choice == 2) DeletingACustomer();
            if (choice == 3) UpdatingACustomer();
            if (choice == 4) SearchingForACustomer();
            if (choice == 5) ReadingACustomer();
            if (choice == 6) SeeTheCustomerList();
            if (choice == 7) MenuCatalog.TheMenu();
            else Console.WriteLine("The END");
        }

        public Customer Create(string name, string mail, int telephoneNumber, int numberOfCustomer)
        {
            Customer customer = new Customer(name, mail, telephoneNumber, numberOfCustomer);
            _listOfCustomers.Add(customer);
            return customer;
        }

        public static void CreatingACustomer()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("YOU ARE CREATING A CUSTOMER");
                Console.ResetColor();
                string name = InputFromUser.GetName("Customer");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Type the mail then press enter");
                Console.ResetColor();
                string mail = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Type the telephonenumber then press enter");
                Console.ResetColor();
                int telephoneNumber = InputFromUser.GetNumber();
                int numberOfCustomer = _listOfCustomers.Count + 1;
                Customer cu = new Customer(name, mail, telephoneNumber, numberOfCustomer);
                _listOfCustomers.Add(cu);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{cu.Name} has been created.");
                Console.ResetColor();
                Console.WriteLine($"Your new customer will be added to the customer list as {ListOfCustomers.Count + 1}");
                if (!InputFromUser.EndingTheLoop("Create", "Customer")) break;
            }
            MenuForCustomers();
        }

        public static void DeletingACustomer()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("YOU ARE DELETING A CUSTOMER");
                Console.ResetColor();
                PrintingACustomerList();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Choose a customer you want to delete then press enter");
                Console.ResetColor();
                Customer deletingACustomer = ListOfCustomers[InputFromUser.NumberInputUser(ListOfCustomers.Count)-1];
                _listOfCustomers.Remove(deletingACustomer);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{deletingACustomer} has been deleted from the listof customers.");
                Console.ResetColor();
                if (_listOfCustomers.Count == 0) break;
                if (!InputFromUser.EndingTheLoop("Deleting", "Customer")) break;
            }
            MenuForCustomers();
        }

        public static void UpdatingACustomer()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("YOU ARE UPDATING A CUSTOMER");
                Console.ResetColor();
                PrintingACustomerList();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Choose a customer number to update the customer then press enter");
                Console.ResetColor();
                Customer updatingACustomer = ListOfCustomers[InputFromUser.NumberInputUser(ListOfCustomers.Count) - 1];
                Console.WriteLine(updatingACustomer);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("What do you want to update on the chosen customer?");
                Console.ResetColor();
                List<string> list = new List<string>()
                {
                    "Name",
                    "Price",
                    "Telephonenumber"
                };
                int updatingWhat = InputFromUser.StringChoice(list);
                switch (updatingWhat)
                {
                    case 1:
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen; 
                            Console.WriteLine("Type the name of the customer then press enter");
                            Console.ResetColor();
                            updatingACustomer.Name = InputFromUser.GetName("Customer");
                            break;
                        }
                    case 2:
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Type the mail of the customer then press enter");
                            Console.ResetColor();
                            string mail = Console.ReadLine();
                            updatingACustomer.Mail = mail;
                            break;
                        }
                    case 3:
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Type the telephonenumber of the customer then press enter");
                            Console.ResetColor();
                            int telephoneNumber = InputFromUser.GetNumber();
                            updatingACustomer.TelephoneNumber = telephoneNumber;
                            break;
                        }
                }
                if (!InputFromUser.EndingTheLoop("Updating", "Customer")) break;
            }
            MenuForCustomers();
        }

        public static void SearchingForACustomer()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("YOU ARE SEARCHING FOR A CUSTOMER");
                Console.ResetColor();
                PrintingACustomerList();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Search for a customer by name");
                Console.ResetColor();
                string name = Console.ReadLine();
                Customer searchingForACustomer = Searching(name);
                Console.ForegroundColor = ConsoleColor.Red;
                if (searchingForACustomer == null) Console.WriteLine("Not Found");
                else
                {
                    Console.WriteLine(searchingForACustomer);
                    foreach(var order in searchingForACustomer.Ordre)
                    {
                        order.PrintingTheOrder();
                    }
                    if (!InputFromUser.EndingTheLoop("Searching for a", "Customer")) break;
                }
            }
            MenuForCustomers();
        }

        public static Customer Searching(string name)
        {
            Customer searchingForACustomer = _listOfCustomers.Find(k => k.Name == name);
            return searchingForACustomer;
        }

        public static void ReadingACustomer()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("YOU ARE READING A CUSTOMER");
                Console.ResetColor();
                Console.WriteLine("Search for a customer by telephonenumber");
                PrintingACustomerList();
                int telephoneNumber= InputFromUser.NumberInputUser(_listOfCustomers.Count);
                Customer readingACustomer = _listOfCustomers.Find(k => k.TelephoneNumber == telephoneNumber);
                Console.WriteLine(readingACustomer);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Do you wish to read another customer? Y/N");
                Console.ResetColor();
                if (!InputFromUser.PickNoOrYes()) break;
            }
            MenuForCustomers();
        }

        public static void SeeTheCustomerList()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("HERE IS THE LIST OF CUSTOMERS");
            Console.ResetColor();
            PrintingACustomerList();
            MenuForCustomers();
        }

        public static void PrintingACustomerList()
        {
            int number = 1;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("______________________________THE MENU____________________________________");
            Console.ResetColor();
            foreach (var customer in _listOfCustomers)
            {
                Console.WriteLine($"{number}, {customer}");
                number++;
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("__________________________________________________________________________");
        }
    }
}
