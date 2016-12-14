using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataBank;
using Console = KataBank.Console;

namespace TestAccount {
    class Program {
        static void Main(string[] args) {
            var console = new Console();
            var date = new CustomDate();
            var operations = new Operations(date);
            var account = new AccountService(console, operations);

            account.Deposit(1000);
            account.Withdraw(100);
            account.Deposit(500);
            account.PrintStatements();
            System.Console.ReadLine();
        }
    }
}
