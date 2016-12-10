using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NSubstitute;

namespace KataBank.Tests
{
    public class AccountServiceAcceptanceTest
    {
        [Fact(Skip = "Not finished yet")]
        public void should_print_statement_containing_all_transactions()
        {
            var console = Substitute.For<Printer>();
            var date = Substitute.For<Date>();
            date.Now().Returns(
                new DateTime(2014, 04, 01), 
                new DateTime(2014, 04, 02), 
                new DateTime(2014, 04, 10)
            );
            var account = new AccountService(console, date);

            account.Deposit(1000);
            account.Withdraw(100);
            account.Deposit(500);
            account.PrintStatements();

            console.Received().PrintLine("DATE | AMOUNT | BALANCE");
            console.Received().PrintLine("10/04/2014 | 500 | 1400");
            console.Received().PrintLine("02/04/2014 | -100 | 900");
            console.Received().PrintLine("01/04/2014 | 1000 | 1000");
        }
    }
}
