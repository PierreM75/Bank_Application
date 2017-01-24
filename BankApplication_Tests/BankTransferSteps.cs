using BankServiceModel;
using NFluent;
using TechTalk.SpecFlow;

namespace BankApplicationTests
{
    [Binding]
    public class BankTransferSteps
    {
        private readonly BankApplicationContext bankApplicationContext = new BankApplicationContext();

        [Given(@"a client (.*) bank account with a balance of (.*)€ on (.*)")]
        public void GivenAClientNameBankAccountWithABalanceOf(string client, int amount, string date)
        {
            bankApplicationContext.CreateClientAccount(client, amount, date);
        }
        
        [Given(@"also another client (.*) bank account with a balance of (.*)€ on (.*)")]
        public void GivenAlsoAnotherClientNameBankAccountWithABalanceOf(string client, int amount, string date)
        {
            bankApplicationContext.CreateClientAccount(client, amount, date);
        }
        
        [When(@"the client (.*) do a transfert of (.*)€ on (.*) to the account client (.*)")]
        public void WhenTheClientNameDoATransfertOfToTheClientNameAccount(string client1, int amount, string date, string client2)
        {
            bankApplicationContext.Transfert(client1, client2, amount, date);
        }
        
        [Then(@"Client (.*) should see a balance account equal to (.*)€")]
        public void ThenClientNameShouldSeeABalanceAccountEqualTo(string client, int amount)
        {
            Check.That(bankApplicationContext.GetBalance(client)).Equals(amount);
        }
        
        [Then(@"Client (.*) should be allowed to transfert money\.")]
        public void ThenClientNameShouldBeAllowedToTransfertMoney(string client)
        {
            Check.That(bankApplicationContext.Message()).Equals(MessageServiceType.Success.ToString());
        }

        [Then(@"Client (.*) should not be allowed to transfert money\.")]
        public void ThenClientNameShouldNotBeAllowedToTransfertMoney(string client)
        {
            Check.That(bankApplicationContext.Message()).Equals(MessageServiceType.InsufficientFund.ToString());

        }
    }
}
