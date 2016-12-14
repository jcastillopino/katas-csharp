using System;
using System.Collections.Generic;

namespace KataBank {
    public class Console : IPrinter {
        public void Print(Stack<Operation> history) {
            // This class should be responsible of print format
            PrintLine("DATE | AMOUNT | BALANCE");
            foreach (var item in history)
                PrintLine(item.Format());
        }

        public void PrintLine(string line) {
            System.Console.WriteLine(line);
        }
    }

    public static class OperationFormater {
        public static string Format(this Operation value) {
            return $"{value.Date.ToShortDateString()} | {value.Amount} | {value.Balance}";
        }
    }
}