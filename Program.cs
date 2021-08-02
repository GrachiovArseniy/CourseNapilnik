using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter_2.Task_1
{
    internal class Program
    {
        private Pathfinder pathfinder1 = new Pathfinder(new FileWriter());
        private Pathfinder pathfinder2 = new Pathfinder(new ConsoleWriter());
        private Pathfinder pathfinder3 = new Pathfinder(new SecureWriter(new FileWriter()));
        private Pathfinder pathfinder4 = new Pathfinder(new SecureWriter(new ConsoleWriter()));
        private Pathfinder pathfinder5 = new Pathfinder(new Plently(
                                                    new ConsoleWriter(),
                                                    new SecureWriter(new FileWriter())));
    }
}
