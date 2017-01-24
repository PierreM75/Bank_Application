using BankServiceModel;
using NFluent;
using TechTalk.SpecFlow;


namespace BankApplicationTests
{
    [Binding]
    public class BankBasicOperationSteps
    {
        private readonly BankApplicationContext bankApplicationContext = new BankApplicationContext();
        private readonly string clientName = "DefaultClient";

        [Given(@"a empty client bank account")]
        public void GivenAEmptyClientBankAccount()
        {
            bankApplicationContext.CreateClientAccount(clientName, 0, "01/01/2001");
        }

        [When(@"the client do a deposit of (.*)€ on (.*)")]
        public void WhenTheClientDoADeposit(int amount, string date)
        {
            bankApplicationContext.Deposit(clientName, amount, date);
        }

        [When(@"the client do a withdrawal of (.*)€ on (.*)")]
        public void WhenTheClientDoAWithdrawal(int amount, string date)
        {
            bankApplicationContext.Withdrawal(clientName, amount, date);
        }

        [Then(@"he should see a balance account equal to (.*)€")]
        public void ThenHeShouldSeeABalanceAccountEqualTo(int amount)
        {
            bankApplicationContext.GetBalance(clientName);
        }
        
        [Then(@"he should not be allowed to withdraw money\.")]
        public void ThenHeShouldNotBeAllowedToWithdrawMoney()
        {
            Check.That(bankApplicationContext.Message()).Equals(MessageServiceType.InsufficientFund.ToString());
        }

        [Then(@"he should be allowed to withdraw money\.")]
        public void ThenHeShouldBeAllowedToWithdrawMoney()
        {
            Check.That(bankApplicationContext.Message()).Equals(MessageServiceType.Success.ToString());
        }
    }
}