using System;
using System.Collections.Generic;
using System.Text;

namespace UML_2___Pizza_Store_2
{
    public class Pizza
    {
        #region 
        private string _nameOfPizza;
        private int _priceOfPizza;
        private int _numberOfThePizza;
        #endregion

        #region 
        public Pizza(string nameOfPizza, int priceOfPizza, int numberOfThePizza)
        {
            _nameOfPizza = nameOfPizza;
            _priceOfPizza = priceOfPizza;
            _numberOfThePizza = numberOfThePizza;
        }
        #endregion

        #region 
        public string NameOfPizza 
        { get { return _nameOfPizza; } set { _nameOfPizza = value; } }

        public int PriceOfPizza 
        { get { return _priceOfPizza; } set { _priceOfPizza = value; } }
       
        public int NumberOfThePizza 
        { get { return _numberOfThePizza; } set { _numberOfThePizza = value; } }
        #endregion

        #region
        public override string ToString()
        {
            return $"{_nameOfPizza}, {_priceOfPizza:C}";
        }
        #endregion
    }
}
