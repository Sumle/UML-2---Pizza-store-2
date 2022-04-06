using System;
using System.Collections.Generic;
using System.Text;

namespace UML_2___Pizza_Store_2
{
    public class Ordre
    {
        private int _id;
        private List<Pizza> _pizzas;
        private Customer _customer;

        public Ordre(Customer customer)
        {
            _customer = customer;
            _pizzas = new List<Pizza>();
        }
        public List<Pizza> Pizzas { get { return _pizzas; } }
        public Customer OrderCustomer { get { return _customer; } set { _customer = value; } }
        public int ID { get { return _id; } set { _id = value; } }
        
        public override string ToString()
        {
            return $"Id {_id}. {_customer.Name}";
        }

        public void PrintingTheOrder()
        {
            Console.WriteLine($"Order ID: {_id}. Customer {_customer.Name}. ");
        }
    }
}
