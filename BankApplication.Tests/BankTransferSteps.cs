using BankApplication.Model;
using NFluent;
using TechTalk.SpecFlow;

namespace BankApplication.Tests
{
    [Binding]
    public class BankTransferSteps
    {
        private readonly BankApplicationContext bankApplicationContext = new BankApplicationContext();
        
        [Given(@"a client (.*) bank account with a balance of (.*)€ on (.*)")]
        [Given(@"another client (.*) bank account with a balance of (.*)€ on (.*)")]
        public void GivenAClientNameBankAccountWithABalanceOf(string client, int amount, string date)
        {
            bankApplicationContext.CreateClientAccount(client, amount, date);
            Check.That(bankApplicationContext.Message().Message()).Equals($"{date} - Deposit - {amount}");
        }

        [When(@"the client (.*) do a transfert of (.*)€ on (.*) to the account client (.*)")]
        public void WhenTheClientNameDoATransfertOfToTheClientNameAccount(string client1, int amount, string date, string client2)
        {
            bankApplicationContext.Transfert(client1, client2, amount, date);
            Check.That(bankApplicationContext.Message().Message()).Equals($"{date} - Transfer to {client2} - -{amount}");
        }
        
        [Then(@"the client (.*) should see a balance account equal to (.*)€")]
        public void ThenClientNameShouldSeeABalanceAccountEqualTo(string client, int amount)
        {
            Check.That(bankApplicationContext.GetBalance(client)).Equals(amount);
        }
        
        [Then(@"the client (.*) should be allowed to transfert money\.")]
        public void ThenClientNameShouldBeAllowedToTransfertMoney(string client)
        {
            Check.That(bankApplicationContext.Message().Status()).Equals(BankStatus.Success);
        }

        [Then(@"the client (.*) should not be allowed to transfert money\.")]
        public void ThenClientNameShouldNotBeAllowedToTransfertMoney(string client)
        {
            Check.That(bankApplicationContext.Message().Status()).Equals(BankStatus.InsufficientFund);
        }
    }
}
