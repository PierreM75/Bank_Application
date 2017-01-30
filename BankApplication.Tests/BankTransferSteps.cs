using BankApplication.Model;
using NFluent;
using TechTalk.SpecFlow;

namespace BankApplication.Tests
{
    [Binding]
    public class BankTransferSteps
    {
        private BankApplicationTest context;

        [BeforeScenario]
        public void Setup()
        {
            context = new BankApplicationTest();
        }

        [Given(@"a client (.*) bank account with a balance of (.*)€ on (.*)")]
        [Given(@"another client (.*) bank account with a balance of (.*)€ on (.*)")]
        public void GivenAClientNameBankAccountWithABalanceOf(string client, int amount, string date)
        {
            context.CreateClientAccount(client, amount, date);
        }

        [When(@"the client (.*) do a transfert of (.*)€ on (.*) to the account client (.*)")]
        public void WhenTheClientNameDoATransfertOfToTheClientNameAccount(string client1, int amount, string date,
            string client2)
        {
            context.Transfert(client1, client2, amount, date);
        }

        [Then(@"the client (.*) should see a balance account equal to (.*)€")]
        public void ThenClientNameShouldSeeABalanceAccountEqualTo(string client, int amount)
        {
            Check.That(context.GetBalance(client)).Equals(amount);
        }

        [Then(@"the client (.*) should be allowed to transfert money\.")]
        public void ThenClientNameShouldBeAllowedToTransfertMoney(string client)
        {
            Check.That(context.Message().Status()).Equals(TransactionStatus.Success);
        }

        [Then(@"the client (.*) should not be allowed to transfert money\.")]
        public void ThenClientNameShouldNotBeAllowedToTransfertMoney(string client)
        {
            Check.That(context.Message().Status()).Equals(TransactionStatus.InsufficientFund);
        }

        [Then(@"the client (.*) should be alerted that operation is invalid\.")]
        public void ThenHeShouldBeAlertedThatOperationIsInvalid(string client)
        {
            Check.That(context.Message().Status()).Equals(TransactionStatus.InvalidOperation);
        }
    }
}