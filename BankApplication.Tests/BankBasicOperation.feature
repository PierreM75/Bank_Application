Feature: Bank Basic Operation
	In order to manage a great bank application, 
	I want to do some basic account operation like deposit and withdrawal
	To verify this feature I need to verify the account balance.
@mytag

Scenario: Deposit cash on an account
	Given a client Name1 bank account with a balance of 0€ on 01/01/2017
	When the client Name1 do a deposit of 1000€ on 13/01/2017
	Then the client Name1 should see a balance account equal to 1000€

Scenario: Deposit cash on an account with invalid amount
	Given a client Name1 bank account with a balance of 0€ on 01/01/2017
	When the client Name1 do a deposit of -1000€ on 13/01/2017
	Then the client Name1 should see a balance account equal to 0€
	Then the client Name1 should be alerted that operation is invalid.

Scenario: Withdrawal cash on an account
	Given a client Name1 bank account with a balance of 0€ on 01/01/2017
	When the client Name1 do a deposit of 2000€ on 13/01/2017
	And the client Name1 do a withdrawal of 1000€ on 14/01/2017
	Then the client Name1 should see a balance account equal to 1000€
	And the client Name1 should be allowed to withdraw money.

Scenario: Withdrawal cash on an account with invalid amount
	Given a client Name1 bank account with a balance of 0€ on 01/01/2017
	When the client Name1 do a withdrawal of -1000€ on 14/01/2017
	Then the client Name1 should see a balance account equal to 0€
	And the client Name1 should be alerted that operation is invalid.

Scenario: Withdrawal cash on an account has unsufficient fund
	Given a client Name1 bank account with a balance of 0€ on 01/01/2017
	When the client Name1 do a withdrawal of 1000€ on 13/01/2017
	Then the client Name1 should see a balance account equal to 0€
	And the client Name1 should not be allowed to withdraw money.

Scenario: Execute many basic operations on an account
	Given a client Name1 bank account with a balance of 0€ on 01/01/2017
	When the client Name1 do a deposit of 5000€ on 12/01/2017
	And the client Name1 do a withdrawal of 1000€ on 13/01/2017
	And the client Name1 do a withdrawal of 1000€ on 14/01/2017
	Then the client Name1 should see a balance account equal to 3000€
	And the client Name1 should be allowed to withdraw money.