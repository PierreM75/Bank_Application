Feature: Bank Basic Operation
	In order to manage a great bank application, 
	I want to do some basic account operation like deposit and withdrawal
	To verify this feature I need to verify the account balance.
@mytag

Scenario: Deposit cash on an account
	Given an empty client bank account
	When the client do a deposit of 1000€ on 13/01/2017
	Then the client should see a balance account equal to 1000€

Scenario: Deposit cash on an account with invalid amount
	Given an empty client bank account
	When the client do a deposit of -1000€ on 13/01/2017
	Then the client should see a balance account equal to 0€
	Then the client should be alerted that operation is invalid.

Scenario: Withdrawal cash on an account
	Given an empty client bank account
	When the client do a deposit of 2000€ on 13/01/2017
	And the client do a withdrawal of 1000€ on 14/01/2017
	Then the client should see a balance account equal to 1000€
	And the client should be allowed to withdraw money.

Scenario: Withdrawal cash on an account with invalid amount
	Given an empty client bank account
	When the client do a withdrawal of -1000€ on 14/01/2017
	Then the client should see a balance account equal to 0€
	And the client should be alerted that operation is invalid.

Scenario: Withdrawal cash on an account has unsufficient fund
	Given an empty client bank account
	When the client do a withdrawal of 1000€ on 13/01/2017
	Then the client should see a balance account equal to 0€
	And the client should not be allowed to withdraw money.

Scenario: Execute many basic operations on an account
	Given an empty client bank account
	When the client do a deposit of 5000€ on 12/01/2017
	And the client do a withdrawal of 1000€ on 13/01/2017
	And the client do a withdrawal of 1000€ on 14/01/2017
	Then the client should see a balance account equal to 3000€
	And the client should be allowed to withdraw money.