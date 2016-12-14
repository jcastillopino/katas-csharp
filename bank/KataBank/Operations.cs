using System.Collections.Generic;

namespace KataBank {
    public class Operations : IOperations {
        private int _balance;
        private readonly Stack<Operation> _history;
        private readonly IDate _date;

        public Operations() {
            // For Unit Test
            _date = new EmptyDate();
            _balance = 0;
            _history = new Stack<Operation>();
        }
        public Operations(IDate date) {
            _date = date;
            _balance = 0;
            _history = new Stack<Operation>();
        }

        public void Withdraw(int amount) {
            _balance -= amount;
            _history.Push(new Operation {
                Amount = amount * -1,
                Balance = _balance,
                Date = _date.Now()
            });
        }

        public void Deposit(int amount) {
            _balance += amount;
            _history.Push(new Operation {
                Amount = amount,
                Balance = _balance,
                Date = _date.Now()
            });

        }

        public int Balance() {
            return _balance;
        }

        public Stack<Operation> GetHistory() {
            return _history;
        }
    }
}