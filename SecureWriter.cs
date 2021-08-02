using System;

namespace Chapter_2.Task_1
{
    internal class SecureWriter : ILogger
    {
        private ILogger _logger;

        public SecureWriter(ILogger logger)
        {
            _logger = logger ?? throw new InvalidOperationException();
        }

        public void Write(string message)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                _logger.Write(message);
            }
        }
    }
}
