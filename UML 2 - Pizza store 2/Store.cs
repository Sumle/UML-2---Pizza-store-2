using System;
using System.Collections.Generic;
using System.Text;

namespace UML_2___Pizza_Store_2
{
    public class Store
    {
        private static MenuCatalog _menuCatalog;
        private static CustomerCatalog _customerCatalog;

        public Store()
        {
            _menuCatalog = new MenuCatalog();
            _customerCatalog = new CustomerCatalog();
        }

        public void Test()
        {
            Pizza p1 = _menuCatalog.CreatingPizza("Hawaii", 79);
            Pizza p2 = _menuCatalog.CreatingPizza("Vegetarian", 79);
            Pizza p3 = _menuCatalog.CreatingPizza("Bolognese", 85);
            Pizza p4 = _menuCatalog.CreatingPizza("Magarita", 79);

            Customer c1 = _customerCatalog.Create("Kurt Jacobsen", "kj@gmail.com", 1, 9);
            Customer c2 = _customerCatalog.Create("Melanie Mortensen", "mm@gmail.com", 2, 8);
            Customer c3 = _customerCatalog.Create("Lasse Hovgaard", "lh@gmail.com", 3, 7);
            Customer c4 = _customerCatalog.Create("Bodil Hansen", "bh@gmail.com", 4, 6);
        }

        public void Start()
        {
            Test();
            MenuCatalog.TheMenu();
        }
    }
}