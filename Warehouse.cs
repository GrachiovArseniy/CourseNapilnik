using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_2
{
    internal class Warehouse
    {
        private readonly List<Cell> _stockGoods = new List<Cell>();
        private readonly int _size;

        public Warehouse(int size)
        {
            _size = size;
        }

        public void Delive(Good good, int count)
        {
            if (FilledIn() + count <= _size)
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
            else
            {
                throw new Exception("Ran out of space in the warehouse!");
            }
        }

        public Cell Export(Good good, int count)
        {
            if (Delivered(good, count))
            {
                Cell cell = _stockGoods.FirstOrDefault(cell => cell.Good == good);
                _stockGoods[_stockGoods.IndexOf(cell)].Count -= count;
                return new Cell(good, count);
            }
            else
            {
                throw new Exception("There is no necessary quantity of goods in warehouse!");
            }
        }

        public void WriteAllGoods()
        {
            foreach (var cell in _stockGoods)
            {
                Console.WriteLine($"{cell.Good} - {cell.Count}");
            }
        }

        public bool Delivered(Good good, int count)
        {
            Cell cell = _stockGoods.FirstOrDefault(cell => cell.Good == good);

            return cell != null && cell.Count >= count;
        }

        private int FilledIn()
        {
            int result = 0;

            foreach (var cell in _stockGoods)
            {
                result += cell.Count;
            }

            return result;
        }
    }
}
