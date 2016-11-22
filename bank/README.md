## Goal
Develop a program to manage the transactions of a bank account.

The transactions are: deposit money into the account, and withdraw from the account.

We need to be able to print into the console the result.
## Requirement
You cannot change the signature of the public interface (the class AccountService).
## Code
	class AccountService {

      // <summary>
      //   Add an amount into the account.
      // </summary>
      public void Deposit(int amount)
      {
      }

      // <summary>
      //   Remove an amount from the account.
      // </summary>
      public void Withdraw($amount)
      {
      }

      // <summary>
      //   Print the statements containing all the transactions in the console
      // </summary>
      public void PrintStatements()
      {
      }
	}
##Acceptance test

	[Test]
	public void should_print_statement_containing_all_transactions() {

    	account.Deposit(1000);
    	account.Withdraw(100);
    	account.Deposit(500);

    	account.PrintStatement();

    	console.Received().PrintLine("DATE | AMOUNT | BALANCE");
    	console.Received().PrintLine("10/04/2014 | 500 | 1400");
    	console.Received().PrintLine("02/04/2014 | -100 | 900");
    	console.Received().PrintLine("01/04/2014 | 1000 | 1000");
	}

## Tools


### Example of Mock

	[Test]
	public void should_interact_with_the_mock() {
    	collaborator = Substitute.For<Collaborator>();       
    	MyClass myClass = new MyClass(collaborator);

    	myClass.Run();

    	collaborator.Received().Collaborate();
	}
### Example of Stub    

	[Test]
	public void should_retrieve_the_stub_response(){
    	collaborator = Substitute.For<Collaborator>();
    	String response = "collaborator response";
    	calculator.Collaborate().Returns(response);
    	MyClass myClass = new MyClass(collaborator);

    	String result = myClass.Run();

    	Assert.That(result, Is.EqualTo(response)); 
	I}
