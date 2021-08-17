using System;
using ExtensionMethods;
using System.Collections.Generic;
using System.Text;

namespace Chapter_2.Task_1
{
    internal class ConsoleWriter : ILogger
    {
        public void Write(string message)
        {
            if (message.IsInvalid())
            {
                throw new InvalidOperationException();
            }

            Console.WriteLine($"[{DateTime.UtcNow}] " + message.Trim());
        }
    }
}
