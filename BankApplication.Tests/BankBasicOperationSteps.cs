using BankApplication.Model;
using NFluent;
using TechTalk.SpecFlow;

namespace BankApplication.Tests
{
    [Binding]
    public class BankBasicOperationSteps
    {
        private readonly BankApplicationContext bankApplicationContext = new BankApplicationContext();
        private readonly string clientName = "DefaultClient";

        [Given(@"a empty client bank account")]
        public void GivenAEmptyClientBankAccount()
        {
            var date = "01-01-2001";
            bankApplicationContext.CreateClientAccount(clientName, 0, date);
            Check.That(bankApplicationContext.Message().Message()).Equals($"{date} - Deposit - 0");
        }

        [When(@"the client do a deposit of (.*)€ on (.*)")]
        public void WhenTheClientDoADeposit(int amount, string date)
        {
            bankApplicationContext.Deposit(clientName, amount, date);
            Check.That(bankApplicationContext.Message().Message()).Equals($"{date} - Deposit - {amount}");
        }

        [When(@"the client do a withdrawal of (.*)€ on (.*)")]
        public void WhenTheClientDoAWithdrawal(int amount, string date)
        {
            bankApplicationContext.Withdrawal(clientName, amount, date);
            Check.That(bankApplicationContext.Message().Message()).Equals($"{date} - Withdrawal - -{amount}");
        }

        [Then(@"he should see a balance account equal to (.*)€")]
        public void ThenHeShouldSeeABalanceAccountEqualTo(int amount)
        {
            Check.That(bankApplicationContext.GetBalance(clientName).Equals(amount));
        }

        [Then(@"he should not be allowed to withdraw money\.")]
        public void ThenHeShouldNotBeAllowedToWithdrawMoney()
        {
            Check.That(bankApplicationContext.Message().Status()).Equals(BankStatus.InsufficientFund);
        }

        [Then(@"he should be allowed to withdraw money\.")]
        public void ThenHeShouldBeAllowedToWithdrawMoney()
        {
            Check.That(bankApplicationContext.Message().Status()).Equals(BankStatus.Success);
        }
    }
}