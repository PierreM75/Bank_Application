Feature: Bank Transfer to another client in the same bank
	In order to manage a great bank application, 
	As a bank user,
	I want to transfert fund from my account to another client account in the same bank. 
	To verify this feature I need to verify the account balance.
@mytag

Scenario: Transfert to another client in the same bank
	Given a client Name1 bank account with a balance of 1000€ on 01-01-2017
	Given another client Name2 bank account with a balance of 0€ on 01-01-2017
	When the client Name1 do a transfert of 1000€ on 13-01-2017 to the account client Name2 
	Then the client Name2 should see a balance account equal to 1000€
	And the client Name1 should be allowed to transfert money.

Scenario: Transfert to another client in the same bank with unsufisient funds.
	Given a client Name1 bank account with a balance of 0€ on 01-01-2017
	Given another client Name2 bank account with a balance of 0€ on 01-01-2017
	When the client Name1 do a transfert of 1000€ on 01-01-2017 to the account client Name2
	Then the client Name2 should see a balance account equal to 0€
	And the client Name1 should not be allowed to transfert money.