using System;
using System.Collections.Generic;
using System.Text;

namespace UML_2___Pizza_Store_2
{
    public class Customer
    {
        private string _name;
        private string _mail;
        private int _telephoneNumber;
        private int _numberOfCustomer;
        private List<Ordre> _ordre;

        public Customer(string name, string mail, int telephoneNumber, int numberOfCustomer)
        {
            _name = name;
            _mail = mail;
            _telephoneNumber = telephoneNumber;
            _numberOfCustomer = numberOfCustomer;
            _ordre = new List<Ordre>();
        }

        public string Name { get { return _name; } set { _name = value; } }
        public string Mail { get { return _mail; } set { _mail = value; } }
        public int TelephoneNumber { get { return _telephoneNumber; } set { _telephoneNumber = value; } }
        public int NumberOfCustomer { get { return _numberOfCustomer; } set { _numberOfCustomer = value; } }
        public List<Ordre> Ordre { get { return _ordre; } set { _ordre = value;} }

        public override string ToString()
        {
            return $"Name: {_name}, Mail: {_mail}, Telephonenumber: {_telephoneNumber}, Number of customer: {_numberOfCustomer}";
        }

        public void PrintingTheOrder()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (_ordre.Count == 0)
                Console.WriteLine("There are no orders.");
            else
            {
                foreach (var ordre in _ordre)
                {
                    ordre.PrintingTheOrder();
                }
            }
        }
    }
}
