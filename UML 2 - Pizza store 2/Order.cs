using System;
using System.Collections.Generic;
using System.Text;

namespace UML_2___Pizza_Store_2
{
    public class Order
    {
        private List<Pizza> _pizzas;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _pizzas = new List<Pizza>();
        }

        public List<Pizza> Pizzas { get { return _pizzas; } }

        public Customer OrderCustomer { get { return _customer; } set { _customer = value; } }
       
        public void PrintingTheOrder()
        {
            Console.WriteLine($"Customer {_customer.Name}.");
        }
        
        public override string ToString()
        {
            return $"{_customer.Name}";
        }
    }
}
