using BankApplication.Model;
using NFluent;
using TechTalk.SpecFlow;

namespace BankApplication.Tests
{
    [Binding]
    public class BankBasicOperationSteps
    {
        private BankApplicationTest context;
        private string clientName;

        [BeforeScenario()]
        public void Setup()
        {
            context = new BankApplicationTest();
            clientName = "DefaultClient";
        }

        [Given(@"a empty client bank account")]
        public void GivenAEmptyClientBankAccount()
        {
            var date = "01/01/2001";
            context.CreateClientAccount(clientName, 0, date);
        }

        [When(@"the client do a deposit of (.*)€ on (.*)")]
        public void WhenTheClientDoADeposit(int amount, string date)
        {
            context.Deposit(clientName, amount, date);
        }

        [When(@"the client do a withdrawal of (.*)€ on (.*)")]
        public void WhenTheClientDoAWithdrawal(int amount, string date)
        {
            context.Withdrawal(clientName, amount, date);
        }

        [Then(@"he should see a balance account equal to (.*)€")]
        public void ThenHeShouldSeeABalanceAccountEqualTo(int amount)
        {
            Check.That(context.GetBalance(clientName).Equals(amount));
        }

        [Then(@"he should not be allowed to withdraw money\.")]
        public void ThenHeShouldNotBeAllowedToWithdrawMoney()
        {
            Check.That(context.Message().Status()).Equals(BankStatus.InsufficientFund);
        }

        [Then(@"he should be allowed to withdraw money\.")]
        public void ThenHeShouldBeAllowedToWithdrawMoney()
        {
            Check.That(context.Message().Status()).Equals(BankStatus.Success);
        }
        
        [Then(@"he should be alerted that operation is invalid\.")]
        public void ThenHeShouldBeAlertedThatOperationIsInvalid()
        {
            Check.That(context.Message().Status()).Equals(BankStatus.InvalidOperation);
        }
    }
}