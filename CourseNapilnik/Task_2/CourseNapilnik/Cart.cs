using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    internal class Cart
    {
        private readonly Warehouse _warehouse;
        private readonly List<Cell> _orderedGoods = new List<Cell>();

        public Cart(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public void Add(Good good, int count)
        {
            _orderedGoods.Add(_warehouse.Export(good, count));
        }

        public void WriteAllGoods()
        {
            foreach (var good in _orderedGoods)
            {
                Console.WriteLine($"{good.Good} - {good.Count}");
            }
        }

        public Order Order()
        {
            return new Order("???");
        }
    }
}
