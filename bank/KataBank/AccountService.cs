using System.Collections.Generic;

namespace KataBank {
    public class AccountService {
        private readonly IPrinter _printer;
        private readonly IOperations _operations;

        public AccountService(IPrinter console,
            IOperations operations) {
            _printer = console;
            _operations = operations;
        }

        public void Deposit(int amount) {
            _operations.Deposit(amount);
        }

        public void Withdraw(int amount) {
            _operations.Withdraw(amount);
        }

        public void PrintStatements() {
            // TOBEFIXED _printer should be responsible of formating, but
            // we are formating the header here and calling PrintLine for testing
            _printer.PrintLine("DATE | AMOUNT | BALANCE");
            foreach (var item in _operations.GetHistory())
                _printer.PrintLine(item.Format());
            //_printer.Print(_operations.GetHistory());
        }
    }
}
