using System;
using System.IO;
using ExtensionMethods;
using System.Collections.Generic;
using System.Text;

namespace Chapter_2.Task_1
{
    internal class FileWriter : ILogger
    {
        private readonly string _path;

        public FileWriter(string path = "C:/Utilities/CourseNapilnik/Logger")
        {
            if (path.IsInvalid())
            {
                throw new InvalidOperationException();
            }

            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }

            _path = path;
        }

        public void Write(string message)
        {
            if (message.IsInvalid())
            {
                throw new InvalidOperationException();
            }

            File.WriteAllText(_path + $"/{DateTime.UtcNow}", message.Trim());
        }
    }
}
