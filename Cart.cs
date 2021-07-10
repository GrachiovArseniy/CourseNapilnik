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

        public IReadOnlyList<IReadOnlyCell> OrderedGoods => _orderedGoods;

        public void Add(Good good, int count)
        {
            _orderedGoods.Add(_warehouse.Export(good, count));
        }

        public Order Order()
        {
            return new Order("Random string");
        }
    }
}
