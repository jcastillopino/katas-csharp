using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Xunit;
using NSubstitute;

namespace KataBank.Tests {
    public class AccountServiceAcceptanceTest {

        [Fact]
        public void should_print_statement_containing_all_transactions() {
            var console = Substitute.For<IPrinter>();
            var date = new CustomDate();
            var operations = new Operations(date);
            var account = new AccountService(console, operations);

            account.Deposit(1000);
            account.Withdraw(100);
            account.Deposit(500);
            account.PrintStatements();

            console.Received().PrintLine("DATE | AMOUNT | BALANCE");
            console.Received().PrintLine("14/12/2016 | 500 | 1400");
            console.Received().PrintLine("14/12/2016 | -100 | 900");
            console.Received().PrintLine("14/12/2016 | 1000 | 1000");
        }

        [Fact]
        public void Check_Deposit_Collaborator() {
            var console = Substitute.For<IPrinter>();
            var operations = Substitute.For<IOperations>();
            var account = new AccountService(console, operations);

            account.Deposit(100);

            operations.Received().Deposit(100);

        }

        [Fact]
        public void After_WithDraw_100_Amount_Equals_Minus_100() {
            var console = Substitute.For<IPrinter>();
            var operations = Substitute.For<IOperations>();
            var account = new AccountService(console, operations);

            account.Withdraw(100);

            operations.Received().Withdraw(100);
        }

        [Fact]
        public void Account_PrintStatements_Print_Headers() {
            var console = Substitute.For<IPrinter>();
            var operations = Substitute.For<IOperations>();
            operations.GetHistory().Returns(new Stack<Operation>());
            var account = new AccountService(console, operations);

            account.PrintStatements();

            console.Received().PrintLine("DATE | AMOUNT | BALANCE");

        }

        [Fact]
        public void Account_Deposit_100_Balance_100_Ok() {
            var console = Substitute.For<IPrinter>();
            var operations = Substitute.For<IOperations>();
            var account = new AccountService(console, operations);

            account.Deposit(100);

            operations.Received().Deposit(100);

        }

        [Fact]
        public void Account_Withdraw_100_Balance_Minus_100_Ok() {
            var console = Substitute.For<IPrinter>();
            var operations = Substitute.For<IOperations>();
            var account = new AccountService(console, operations);

            account.Withdraw(100);

            operations.Received().Withdraw(100);

        }

        [Fact]
        public void Collaborator_Deposit_100_Balance_100_Ok() {
            var console = Substitute.For<IPrinter>();
            var operations = Substitute.For<IOperations>();
            var account = new AccountService(console, operations);

            account.Deposit(100);

            operations.Received().Deposit(100);
        }

        [Fact]
        public void Account_PrintStatements_Print_WithDeposit() {
            var console = Substitute.For<IPrinter>();
            var operations = Substitute.For<IOperations>();
            var stack = new Stack<Operation>();
            stack.Push(new Operation {
                Amount = 500,
                Balance = 1400,
                Date = new DateTime(2014, 04, 10)
            });
            operations.GetHistory().Returns(stack);
            var account = new AccountService(console, operations);

            account.PrintStatements();

            console.Received().PrintLine("DATE | AMOUNT | BALANCE");
        }

        [Fact]
        private void Operation_Deposit_100_Balance_100() {
            var date = Substitute.For<IDate>();
            var operations = new Operations(date);
            operations.Deposit(100);
            Assert.Equal(100, operations.Balance());
        }

        [Fact]
        private void Operation_Withdraw_100_Balance_Minus_100() {
            var date = Substitute.For<IDate>();
            var operations = new Operations(date);
            operations.Withdraw(100);
            Assert.Equal(-100, operations.Balance());
        }

        [Fact]
        private void Operation_Deposit_100_WritesHistory() {
            var date = Substitute.For<IDate>();
            var operations = new Operations(date);
            operations.Deposit(100);
            Assert.Equal(1, operations.GetHistory().Count);
        }
    }
}
