using System;
using System.Collections.Generic;

namespace KataFizzBuzz {
    public class FizzBuzz {
        private readonly int _initial;
        private readonly int _final;

        public FizzBuzz(int initial, int final) {
            _initial = initial;
            _final = final;
        }

        public List<string> ProcessNumbers() {
            var values = new List<string>();
            for (var i = _initial; i <= _final; i++)
                values.Add(Process(i));
            return values;
        }

        private static string Process(int i) {
            if (IsFizzBuzz(i))
                return "FizzBuzz";
            if (IsFizz(i))
                return "Fizz";
            if (IsBuzz(i))
                return "Buzz";
            else
                return i.ToString();
        }

        private static bool IsFizzBuzz(int i) {
            return IsFizz(i) && IsBuzz(i);
        }

        private static bool IsBuzz(int i) {
            return Has5(i) || IsMultipleOf5(i);
        }

        private static bool IsFizz(int i) {
            return Has3(i) || IsMultipleOf3(i);
        }

        private static bool Has5(int number) {
            return number.ToString().Contains("5");
        }

        private static bool Has3(int number) {
            return number.ToString().Contains("3");
        }

        private static bool IsMultipleOf3(int i) {
            return i % 3 == 0;
        }

        private static bool IsMultipleOf5(int i) {
            return i % 5 == 0;
        }
    }
}
