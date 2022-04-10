using System;
using System.Collections.Generic;
using System.Text;

namespace UML_2___Pizza_Store_2
{
    public class MenuCatalog
    {
        private static List<Pizza> _pizzas;

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
            int choice = Store.ChoicesOfMenu("Pizza");
            if (choice == 1) CreatingPizza();
            if (_pizzas.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have no Pizzas");
                Console.ResetColor();
                Store.TheMenu();
            }
            if (choice == 1) CreatingPizza();
            if (choice == 2) DeletingPizza();
            if (choice == 3) UpdatingPizza();
            if (choice == 4) SearchingForAPizza();
            if (choice == 5) ReadingPizza();
            if (choice == 6) SeeThePizzaMenu(); 
            else Console.WriteLine("The END");
        }

        public static void CreatingPizza()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("YOU ARE CREATING PIZZA");
                Console.ResetColor();
                string nameOfPizza = Store.GetName("Pizza");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Type the price of the pizza then press enter");
                Console.ResetColor();
                int priceOfPizza = Store.GetNumber();
                int numberOfPizza = _pizzas.Count + 1;
                Pizza p = new Pizza(nameOfPizza, priceOfPizza, numberOfPizza);
                _pizzas.Add(p);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{p.NameOfPizza} was created");
                Console.ResetColor();
                if (!Store.EndingTheLoop("Create", "Pizza")) break;
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
                Pizza deletingPizza = Store.GetPizzas(_pizzas);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{deletingPizza.NameOfPizza} was removed");
                Console.ResetColor();
                _pizzas.Remove(deletingPizza);
                if (_pizzas.Count == 0) break;
                if (!Store.EndingTheLoop("Delete", "Pizza")) break;
            }
            PizzaStartMenu();
        }

        public static void UpdatingPizza()
        {
            while (true)
            {
                Pizza updatingPizza = Store.GetPizzas(_pizzas);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Do you want to update anything? And if you want then what?");
                Console.ResetColor();
                List<string> list = new List<string>()
                {
                    "Name",
                    "Price",
                };
                int updatingWhat = Store.StringChoice(list);
                switch (updatingWhat)
                {
                    case 1:
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            updatingPizza.NameOfPizza = Store.GetName("Pizza");
                            Console.ResetColor();
                            break;
                        }
                    case 2:
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Type price of pizza then press enter");
                            Console.ResetColor();
                            int price = Store.GetNumber();
                            updatingPizza.PriceOfPizza = price;
                            break;
                        }
                }
                if (!Store.EndingTheLoop("Update", "Pizza")) break;
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
                    if (!Store.EndingTheLoop("Search for", "Pizza")) break;
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
                int findingNumberOfPizza = Store.NumberInput(_pizzas.Count);
                Pizza findingAPizza = _pizzas.Find(x => x.NumberOfThePizza == findingNumberOfPizza);
                Console.WriteLine(findingAPizza);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Do you want to find another Pizza? Y/N");
                Console.ResetColor();
                if (!Store.PickNoOrYes()) break;
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
                Pizza addingPizzas = _pizzas[Store.NumberInput(_pizzas.Count) - 1];
                order.Pizzas.Add(addingPizzas);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Add more to order? Y/N");
                Console.ResetColor();
                if (!Store.PickNoOrYes())
                {
                    order.PrintingTheOrder();
                    break;
                }
            }
        }
    }
}
