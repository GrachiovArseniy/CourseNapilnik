using System.Collections.Generic;
using System.Linq;

namespace Chapter_1.Task_2
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
            Cell newCell = _warehouse.Export(good, count);

            Cell cell = _orderedGoods.FirstOrDefault(cell => cell.Good == good);

            if (cell == null)
            {
                _orderedGoods.Add(cell);
            }
            else
            {
                cell.Merge(newCell);
            }
        }

        public Order Order()
        {
            return new Order("Random string");
        }
    }
}
