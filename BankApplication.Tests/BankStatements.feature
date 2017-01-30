Feature: Bank Account Statements
	In order to manage a great bank application, 
	I want to get Account statements (include all operations with date, amount and balance for each)
@mytag

Scenario: Show account statement after having basic operations
	Given a client Name1 bank account with a balance of 1000€ on 10/01/2017
	When the client Name1 do a deposit of 2000€ on 13/01/2017
	And the client Name1 do a withdrawal of 500€ on 14/01/2017
	And the client Name1 claims his bank statement
	Then the client Name1 should see the following statements
	|Date		|Operation | Amount  | Balance |
	|14/01/2017 | Debit    | 500.00  | 2500.00 |
	|13/01/2017 | Credit   | 2000.00 | 3000.00 |
	|10/01/2017 | Credit   | 1000.00 | 1000.00 |

Scenario: Show account statement after having disordered basic operations 
	Given a client Name1 bank account with a balance of 1000€ on 10/01/2017
	When the client Name1 do a withdrawal of 500€ on 14/01/2017
	And the client Name1 do a deposit of 2000€ on 13/01/2017
	And the client Name1 claims his bank statement
	Then the client Name1 should see the following statements
	|Date		|Operation | Amount  | Balance |
	|14/01/2017 | Debit    | 500.00  | 2500.00 |
	|13/01/2017 | Credit   | 2000.00 | 3000.00 |
	|10/01/2017 | Credit   | 1000.00 | 1000.00 |