using System.Linq;
using BankApplication.Model;
using BankApplication.Model.Operation;
using NFluent;
using TechTalk.SpecFlow;

namespace BankApplication.Tests
{
    [Binding]
    public class BankApplicationSteps
    {
        private BankApplicationContext context;

        [BeforeScenario]
        public void Setup()
        {
            context = new BankApplicationContext();
        }

        [Given(@"a client (.*) bank account with a balance of (.*)€ on (.*)")]
        [Given(@"another client (.*) bank account with a balance of (.*)€ on (.*)")]
        public void GivenAClientNameBankAccountWithABalanceOf(string client, int amount, string date)
        {
            context.CreateClientAccount(client, amount, date);
        }
        
        [When(@"the client (.*) do a deposit of (.*)€ on (.*)")]
        public void WhenTheClientDoADeposit(string client, int amount, string date)
        {
            context.Deposit(client, amount, date);
        }
        
        [When(@"the client (.*) do a withdrawal of (.*)€ on (.*)")]
        public void WhenTheClientDoAWithdrawal(string client, int amount, string date)
        {
            context.Withdrawal(client, amount, date);
        }
        
        [When(@"the client (.*) do a transfert of (.*)€ on (.*) to the account client (.*)")]
        public void WhenTheClientNameDoATransfertOfToTheClientNameAccount(string client1, int amount, string date, string client2)
        {
            context.Transfert(client1, client2, amount, date);
        }

        [When(@"the client (.*) claims his bank statement")]
        public void WhenTheClientClaimsHisBankStatement(string client)
        {
            context.Statements(client);
        }

        [Then(@"the client (.*) should not be allowed to withdraw money\.")]
        [Then(@"the client (.*) should not be allowed to transfert money\.")]
        public void ThenTheClientShouldNotBeAllowedToWithdrawMoney(string client)
        {
            Check.That(context.Status()).Equals(TransactionStatus.InsufficientFund);
        }

        [Then(@"the client (.*) should be allowed to withdraw money\.")]
        [Then(@"the client (.*) should be allowed to transfert money\.")]
        public void ThenTheClientNameShouldBeAllowedToWithdrawMoney(string client)
        {
            Check.That(context.Status()).Equals(TransactionStatus.Success);
        }

        [Then(@"the client (.*) should be alerted that operation is invalid\.")]
        public void ThenTheClientShouldBeAlertedThatOperationIsInvalid(string client)
        {
            Check.That(context.Status()).Equals(TransactionStatus.InvalidOperation);
        }
        
        [Then(@"the client (.*) should see a balance account equal to (.*)€")]
        public void ThenTheClientShouldSeeABalanceAccountEqualTo(string client, int amount)
        {
            Check.That(context.Balance(client).Equals(amount));
        }

        [Then(@"the client (.*) should see the following statements")]
        public void ThenTheClientShouldSeeTheFollowingStatements(string client, Table table)
        {
            var statements = context.Statements(client).ToList();
            Check.That(statements.Count).Equals(table.RowCount);

            int index = 0;
            foreach (var line in table.Rows)
            {
                var statement = statements[index++];
                var expected =  $"{line[0].Trim()} - {line[1].Trim()} - {line[2].Trim()} - {line[3].Trim()}";
                Check.That(statement.ShowStatement()).Equals(expected);
            }
        }
    }
}