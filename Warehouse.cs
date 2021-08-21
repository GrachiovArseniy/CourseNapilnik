using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter_1.Task_2
{
    internal class Warehouse
    {
        private readonly List<Cell> _stockGoods = new List<Cell>();

        public IReadOnlyList<IReadOnlyCell> StockGoods => _stockGoods;

        public void Delive(Good good, int count)
        {
            var newCell = new Cell(good, count);

            Cell cell = _stockGoods.FirstOrDefault(cell => cell.Good == good);

            if (cell == null)
            {
                _stockGoods.Add(cell);
            }
            else
            {
                cell.Merge(newCell);
            }
        }

        public Cell Export(Good good, int count)
        {
            if (IsInWarehouse(good, count) == false)
            {
                throw new InvalidOperationException();
            }

            Cell cell = _stockGoods.FirstOrDefault(cell => cell.Good == good);
            _stockGoods[_stockGoods.IndexOf(cell)].Count -= count;
            return new Cell(good, count);
        }

        public bool IsInWarehouse(Good good, int count)
        {
            Cell cell = _stockGoods.FirstOrDefault(cell => cell.Good == good);

            return cell != null && cell.Count >= count;
        }
    }
}
