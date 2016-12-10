## Goal
Develop a program to manage the transactions of a bank account.

The transactions are: deposit money into the account, and withdraw from the account.

We need to be able to print into the console the result.
## Requirement
You cannot change the signature of the public interface (the class AccountService).
## Code
	class AccountService {

      public void Deposit(int amount)
      {
      }

      public void Withdraw(int amount)
      {
      }

      public void PrintStatements()
      {
      }
	}

## Acceptance test

	[Fact]
	public void should_print_statement_containing_all_transactions() {
		// Arrange

    	account.Deposit(1000);
    	account.Withdraw(100);
    	account.Deposit(500);
    	account.PrintStatements();

    	console.Received().PrintLine("DATE | AMOUNT | BALANCE");
    	console.Received().PrintLine("10/04/2014 | 500 | 1400");
    	console.Received().PrintLine("02/04/2014 | -100 | 900");
    	console.Received().PrintLine("01/04/2014 | 1000 | 1000");
	}

## Tools

### Example of Mock

	[Fact]
	public void should_interact_with_the_mock() {
    	collaborator = Substitute.For<Collaborator>();       
    	MyClass myClass = new MyClass(collaborator);

    	myClass.Run();

    	collaborator.Received().Collaborate();
	}
### Example of Stub    

	[Fact]
	public void should_retrieve_the_stub_response(){
    	collaborator = Substitute.For<Collaborator>();
    	String response = "collaborator response";
    	calculator.Collaborate().Returns(response);
    	MyClass myClass = new MyClass(collaborator);

    	String result = myClass.Run();

    	Assert.Equal(response, result);
	}
