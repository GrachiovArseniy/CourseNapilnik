using System;
using System.Collections.Generic;

namespace Chapter_2.Task_1
{
    internal class Plently : ILogger
    {
        private List<ILogger> _loggers = new List<ILogger>();

        public Plently(params ILogger[] loggers)
        {
            foreach (ILogger logger in loggers)
            {
                if (logger == null)
                {
                    throw new InvalidOperationException();
                }
            }

            _loggers.AddRange(loggers);
        }

        public void Write(string message)
        {
            foreach (ILogger logger in _loggers)
            {
                logger.Write(message);
            }
        }
    }
}
