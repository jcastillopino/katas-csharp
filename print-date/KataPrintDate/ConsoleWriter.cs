using System;

namespace KataPrintDate
{
    public class ConsoleWriter : IWriteLine {
        public void WriteLine(string text) {
            Console.WriteLine(text);
        }
    }
}