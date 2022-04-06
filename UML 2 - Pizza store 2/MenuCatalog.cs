using System;
using System.Collections.Generic;
using System.Text;

namespace UML_2___Pizza_Store_2
{
    public class MenuCatalog
    {
        private static List<Pizza> _pizzas;
        private const string _nameOfThePizzeria = "Welcome to Big Mammas Pizzeria!";

        public MenuCatalog()
        {
            _pizzas = new List<Pizza>();
        }

        public List<Pizza> Pizzass { get { return _pizzas; } set { _pizzas = value; } }

        public static void PizzaStartMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("HERE IS THE PIZZA MENU");
            Console.ResetColor();
            int choice = InputFromUser.ChoicesOfMenu("Pizza");
            if (choice == 1) CreatingPizza();
            if (_pizzas.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have no Pizzas");
                Console.ResetColor();
                TheMenu();
            }
            if (choice == 1) CreatingPizza();
            if (choice == 2) DeletingPizza();
            if (choice == 3) UpdatingPizza();
            if (choice == 4) SearchingForAPizza();
            if (choice == 5) ReadingPizza();
            if (choice == 6) SeeThePizzaMenu();
            if (choice == 7) TheMenu();
            else Console.WriteLine("The END");
        }

        public static void TheMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(_nameOfThePizzeria);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1. Add a new pizza to the menu");
            Console.WriteLine("2. Delete pizza");
            Console.WriteLine("3. Update pizza");
            Console.WriteLine("4. Search pizza");
            Console.WriteLine("5. Read a pizza");
            Console.WriteLine("6. Display pizza menu");
            Console.WriteLine("7. Add a new customer to the list");
            Console.WriteLine("8. Delete a customer");
            Console.WriteLine("9. Update a customer");
            Console.WriteLine("10. Search for a customer");
            Console.WriteLine("11. Read a customer");
            Console.WriteLine("12. Display the list of customers");
            Console.WriteLine();
            Console.WriteLine("Please type the number you wish to access, and click 'enter'");

            int userInput;
            while (true)
            {
                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                    if (userInput > 12 || userInput < 0)
                    {
                        Console.WriteLine("Please select a number between 0 and 12");
                    }
                    else
                        break;
                }
                catch (System.FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please insert only numbers!");
                    Console.ResetColor();
                }
            }

            if (userInput == 1)
            {
                Console.Clear();
                CreatingPizza();
            }

            else if (userInput == 2)
            {
                Console.Clear();
                DeletingPizza();
            }
            else if (userInput == 3)
            {
                Console.Clear();
                UpdatingPizza();
            }
            else if (userInput == 4)
            {
                Console.Clear();
                SearchingForAPizza();
            }
            else if (userInput == 5)
            {
                Console.Clear();
                ReadingPizza();
            }
            else if (userInput == 6)
            {
                Console.Clear();
                PrintMenu();
            }
            else if (userInput == 7)
            {
                Console.Clear();
                CustomerCatalog.CreatingACustomer();
            }
            else if (userInput == 8)
            {
                Console.Clear();
                CustomerCatalog.DeletingACustomer();
            }
            else if (userInput == 9)
            {
                Console.Clear();
                CustomerCatalog.UpdatingACustomer();
            }
            else if (userInput == 10)
            {
                Console.Clear();
                CustomerCatalog.SearchingForACustomer();
            }
            else if (userInput == 11)
            {
                Console.Clear();
                CustomerCatalog.ReadingACustomer();
            }
            else if (userInput == 12)
            {
                Console.Clear();
                CustomerCatalog.PrintingACustomerList();
            }
        }

        public static void CreatingPizza()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("YOU ARE CREATING PIZZA");
                Console.ResetColor();
                string nameOfPizza = InputFromUser.GetName("Pizza");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Type the price of the pizza then press enter");
                Console.ResetColor();
                int priceOfPizza = InputFromUser.GetNumber();
                int numberOfPizza = _pizzas.Count + 1;
                Pizza p = new Pizza(nameOfPizza, priceOfPizza, numberOfPizza);
                _pizzas.Add(p);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{p.NameOfPizza} was created");
                Console.ResetColor();
                if (!InputFromUser.EndingTheLoop("Create", "Pizza")) break;
            }
            PizzaStartMenu();
        }

        public Pizza CreatingPizza(string nameOfPizza, int priceOfPizza)
        {
            int numberOfPizza = _pizzas.Count + 1;
            Pizza p = new Pizza(nameOfPizza, priceOfPizza, numberOfPizza);
            _pizzas.Add(p);
            return p;
        }

        public static void DeletingPizza()
        {
            while (true)
            {
                Pizza deletingPizza = InputFromUser.GetPizzas(_pizzas);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{deletingPizza.NameOfPizza} was removed");
                Console.ResetColor();
                _pizzas.Remove(deletingPizza);
                if (_pizzas.Count == 0) break;
                if (!InputFromUser.EndingTheLoop("Delete", "Pizza")) break;
            }
            PizzaStartMenu();
        }

        public static void UpdatingPizza()
        {
            while (true)
            {
                Pizza updatingPizza = InputFromUser.GetPizzas(_pizzas);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Do you want to update anything? And if you want then what?");
                Console.ResetColor();
                List<string> list = new List<string>()
                {
                    "Name",
                    "Price",
                };
                int updatingWhat = InputFromUser.StringChoice(list);
                switch (updatingWhat)
                {
                    case 1:
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            updatingPizza.NameOfPizza = InputFromUser.GetName("Pizza");
                            Console.ResetColor();
                            break;
                        }
                    case 2:
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Type price of pizza then press enter");
                            Console.ResetColor();
                            int price = InputFromUser.GetNumber();
                            updatingPizza.PriceOfPizza = price;
                            break;
                        }
                }
                if (!InputFromUser.EndingTheLoop("Update", "Pizza")) break;
            }
            PizzaStartMenu();
        }

        public static void SearchingForAPizza()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("YOU ARE SEARCH FOR PIZZA");
                Console.ResetColor();
                PrintMenu();
                Console.WriteLine("Search for pizza by name");
                string name = Console.ReadLine();
                Pizza searchingForAPizza = SearchingForAPizza(name);
                Console.ForegroundColor = ConsoleColor.Red;
                if (searchingForAPizza == null) Console.WriteLine("Not Found"); 
                else
                {
                    Console.WriteLine(searchingForAPizza);
                    if (!InputFromUser.EndingTheLoop("Search for", "Pizza")) break;
                }
            }
            PizzaStartMenu();
        }
        public static Pizza SearchingForAPizza(string name)
        {
            Pizza searchingForAPizza = _pizzas.Find(x => x.NameOfPizza == name);
            return searchingForAPizza;
        }
        public static void ReadingPizza()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("YOU ARE READING A PIZZA");
                Console.ResetColor();
                Console.WriteLine("Search for pizza by number");
                PrintMenu();
                int findingNumberOfPizza = InputFromUser.NumberInputUser(_pizzas.Count);
                Pizza findingAPizza = _pizzas.Find(x => x.NumberOfThePizza == findingNumberOfPizza);
                Console.WriteLine(findingAPizza);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Do you want to find another Pizza? Y/N");
                Console.ResetColor();
                if (!InputFromUser.PickNoOrYes()) break;
            }
            PizzaStartMenu();
        }

        public static void SeeThePizzaMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("HERE IS THE PIZZA MENU");
            PrintMenu();
            PizzaStartMenu();
        }
        public static void PrintMenu()
        {
            int Number = 1;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("______________________________THE MENU____________________________________");
            Console.ResetColor();
            foreach (var pizza in _pizzas)
            {
                Console.WriteLine($"{Number}. {pizza}");
                Number++;
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("__________________________________________________________________________");
        }
        public void AddPizzasToOrder(Ordre order)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("What pizza did you order?");
                Console.ResetColor();
                PrintMenu();
                Pizza addingPizzas = _pizzas[InputFromUser.NumberInputUser(_pizzas.Count) - 1];
                order.Pizzas.Add(addingPizzas);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Add more to order? Y/N");
                Console.ResetColor();
                if (!InputFromUser.PickNoOrYes())
                {
                    order.PrintingTheOrder();
                    break;
                }
            }
        }
    }
}
