using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    internal interface IReadOnlyCell
    {
        public Good Good { get; }

        public int Count { get; }
    }
}
