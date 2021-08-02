using System;

namespace Chapter_2.Task_1
{
    internal class Pathfinder
    {
        private ILogger _logger;

        public Pathfinder(ILogger logger)
        {
            _logger = logger ?? throw new InvalidOperationException();
        }

        public void Find(string message)
        {
            _logger.Write(message);
        }
    }
}
