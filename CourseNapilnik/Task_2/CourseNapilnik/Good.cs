using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    internal class Good
    {
        private readonly string _name;

        public Good(string name)
        {
            _name = name;
        }

        public string Name => _name;
    }
}
