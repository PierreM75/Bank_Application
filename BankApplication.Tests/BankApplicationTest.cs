using BankApplication.Model;
using NFluent;
using NUnit.Framework;

namespace BankApplication.Tests
{
    public class BankApplicationTest
    {
        private readonly BankApplicationContext context = new BankApplicationContext();
        private TransactionMessage message;

        [SetUp]
        public void SetUp()
        {
            context.CreateClientAccount("client1", 0, "01/01/2017");
            context.CreateClientAccount("client2", 0, "01/01/2017");
        }

        [TestCase("client0", 0, "01/01/2017")]
        [TestCase("client0", -1000, "01/01/2017")]
        [TestCase("client0", 1000, "01/01/2017")]
        public void CreateClientAccount(string clientName, int amount, string date)
        {
            context.CreateClientAccount(clientName, amount, date);
            message = context.Message();
            Check.That(message.Label()).Equals($"{date} - Credit - {amount}");
        }

        [TestCase("client1", 100, "01/01/2017")]
        [TestCase("client1", 0, "01/01/2017")]
        [TestCase("client1", -100, "01/01/2017")]
        public void Deposit(string clientName, int amount, string date)
        {
            context.Deposit(clientName, amount, date);
            message = context.Message();
            Check.That(context.Message().Label()).Equals($"{date} - Credit - {amount}");
        }

        [TestCase("client1", 100, "01/01/2017")]
        [TestCase("client1", 1, "01/01/2017")]
        [TestCase("client1", -100, "01/01/2017")]
        public void Withdrawal(string clientName, int amount, string date)
        {
            context.Withdrawal(clientName, amount, date);
            message = context.Message();
            Check.That(context.Message().Label()).Equals($"{date} - Debit - {amount}");
        }

        [TestCase("client1", "client2", 0, "01/01/2017")]
        [TestCase("client1", "client2", 1000, "01/01/2017")]
        [TestCase("client1", "client2", -1000, "01/01/2017")]
        public void Transfert(string fromClientName, string toClientName, int amount, string date)
        {
            context.Transfert(fromClientName, toClientName, amount, date);
            message = context.Message();
            Check.That(context.Message().Label()).Equals($"{date} - Debit - {amount}");
        }

        internal int GetBalance(string clientName)
        {
            return context.GetBalance(clientName);
        }

        internal TransactionMessage Message()
        {
            return message;
        }
    }
}