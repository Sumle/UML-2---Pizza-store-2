using System;
using System.Collections.Generic;
using System.Text;

namespace UML_2___Pizza_Store_2
{
    public class Store
    {
        private static MenuCatalog _menuCatalog;
        private const string _nameOfThePizzeria = "Welcome to Big Mammas Pizzeria!";

        public Store()
        {
            _menuCatalog = new MenuCatalog();
        }

        public void Test()
        {
            Pizza p1 = _menuCatalog.CreatingPizza("Hawaii", 79);
            Pizza p2 = _menuCatalog.CreatingPizza("Vegetarian", 79);
            Pizza p3 = _menuCatalog.CreatingPizza("Bolognese", 85);
            Pizza p4 = _menuCatalog.CreatingPizza("Magarita", 79);
        }

        public void Start()
        {
            Test();
            TheMenu();
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
            Console.WriteLine();
            Console.WriteLine("Please type the number you wish to access, and click 'enter'");

            int userInput;
            while (true)
            {
                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                    if (userInput > 6 || userInput < 0)
                    {
                        Console.WriteLine("Please select a number between 0 and 6");
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
                MenuCatalog.CreatingPizza();
            }

            else if (userInput == 2)
            {
                Console.Clear();
                MenuCatalog.DeletingPizza();
            }
            else if (userInput == 3)
            {
                Console.Clear();
                MenuCatalog.UpdatingPizza();
            }
            else if (userInput == 4)
            {
                Console.Clear();
                MenuCatalog.SearchingForAPizza();
            }
            else if (userInput == 5)
            {
                Console.Clear();
                MenuCatalog.ReadingPizza();
            }
            else if (userInput == 6)
            {
                Console.Clear();
                MenuCatalog.PrintMenu();
            }
        }

        public static bool PickNoOrYes()
        {
            string inp = Console.ReadKey().KeyChar.ToString().ToUpper();
            Console.WriteLine();
            if (inp == "Y")
            {
                return true;
            }
            return false;
        }

        public static bool EndingTheLoop(string action, string type)
        {
            Console.WriteLine();
            Console.WriteLine($"Do you want to {action} another {type}? Y/N");
            return PickNoOrYes();
        }

        public static int GetNumber()
        {
            bool valid = false;
            int inpNumber = 0;
            int Max = 10000;
            while (!valid)
            {
                string inp = Console.ReadLine();
                Console.WriteLine();
                try
                {
                    inpNumber = Int32.Parse(inp);
                    valid = inpNumber <= Max;
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (inpNumber > Max) Console.WriteLine("Out of range number.");
                    Console.ResetColor();
                }
                catch (Exception)
                {
                    Console.WriteLine("Not valid.");
                }
                if (valid) break;
            }
            return inpNumber;
        }

        public static int NumberInputUser(int countList)
        {
            bool valid = false;
            int inpNumber = 0;
            while (!valid)
            {
                string inp = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
                try
                {
                    inpNumber = Int32.Parse(inp);
                    valid = inpNumber <= countList && inpNumber > 0;
                    if (inpNumber > countList || inpNumber < 1)
                        Console.WriteLine("Out of range.");
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a number.");
                    Console.ResetColor();
                }
                if (valid) break;
            }
            return inpNumber;
        }

        public static Pizza GetPizzas(List<Pizza> pizzas)
        {
            int number = 1;
            foreach (var pizza in pizzas)
            {
                Console.WriteLine($"{number}, {pizza}");
                number++;
            }
            Pizza retrunPizzas = pizzas[NumberInputUser(pizzas.Count) - 1];
            return retrunPizzas;
        }

        public static int ChoicesOfMenu(string str)
        {
            List<string> listMenu = new List<string>()
            {
                $"Add new {str}",
                $"Update {str}",
                $"Delete {str}",
                $"Search for {str}",
                $"Read {str}",
                $"Back to top menu"
            };
            int number = 1;
            foreach (var item in listMenu)
            {
                Console.WriteLine($"{number}. {item}");
                number++;
            }
            int input = NumberInputUser(listMenu.Count);
            return input;
        }

        public static int StringChoice(List<string> list)
        {
            int number = 1;
            foreach (var str in list)
            {
                Console.WriteLine($"{number}. {str}");
                number++;
            }
            int numberToReturn = NumberInputUser(list.Count);
            return numberToReturn;
        }

        public static string GetName(string type)
        {
            string name = string.Empty;
            while (name == string.Empty)
            {
                Console.WriteLine($"Type name of {type}");
                name = Console.ReadLine();
            }
            return name;
        }
    }
}