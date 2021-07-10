using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    internal class Cell : IReadOnlyCell
    {
        public Cell(Good good, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            Good = good;
            Count = count;
        }

        public Good Good { get; private set; }

        public int Count { get; set; }

        public void Merge(Cell newCell)
        {
            if (newCell.Good != Good)
            {
                throw new InvalidOperationException();
            }

            if (newCell.Count <= 0)
            {
                throw new InvalidOperationException();
            }

            Count += newCell.Count;
        }
    }
}
