using System;
using System.Collections.Generic;
using System.Text;

namespace UML_2___Pizza_Store_2
{
    public class Ordre
    {
        private int _id;
        private List<Pizza> _pizzas;

        public Ordre()
        {
            _pizzas = new List<Pizza>();
        }
        public List<Pizza> Pizzas { get { return _pizzas; } }
        public int ID { get { return _id; } set { _id = value; } }
        
        public override string ToString()
        {
            return $"Id {_id}.";
        }

        public void PrintingTheOrder()
        {
            Console.WriteLine($"Order ID: {_id}. ");
        }
    }
}
