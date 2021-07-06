using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    internal class Shop
    {
        private readonly Warehouse _warehouse;

        public Shop(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public Cart Cart()
        {
            return new Cart(_warehouse);
        }
    }
}
