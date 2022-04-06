using System;
using System.Collections.Generic;
using System.Text;

namespace UML_2___Pizza_Store_2
{
    public static class InputFromUser
    {
        public static bool PickNoOrYes()
        {
            string inp = Console.ReadKey().KeyChar.ToString().ToUpper();
            Console.WriteLine();
            if(inp == "Y")
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
            while(!valid)
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
                $"See list of both pizzas and customers",
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
