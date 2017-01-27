using BankApplication.Domain;
using BankApplication.Model;
using BankApplication.Model.Interface;

namespace BankApplication.Tests
{
    internal class BankApplicationContext
    {
        private readonly IClients clients = new Clients();
        private BankMessage message;

        internal void CreateClientAccount(string clientName, int amount, string date)
        {
            var client = new Client(clientName);
            clients.Create(client);
            message = client.Deposit(new OperationDetail(date.ConvertDate(), amount));
        }

        internal void Deposit(string clientName, int amount, string date)
        {
            message = GetClient(clientName).Deposit(new OperationDetail(date.ConvertDate(), amount));
        }

        internal void Withdrawal(string clientName, int amount, string date)
        {
            var operation = new OperationDetail(date.ConvertDate(), amount);
            message = GetClient(clientName).Withdrawal(operation);
        }

        internal void Transfert(string fromClientName, string toClientName, int amount, string date)
        {
            var fromClient = GetClient(fromClientName);
            var toClient = GetClient(toClientName);
            var operation = new OperationDetail(date.ConvertDate(), amount);
            message = fromClient.Transfert(toClient, operation);
        }

        internal int GetBalance(string clientName)
        {
            return GetClient(clientName).Balance();
        }

        internal BankMessage Message()
        {
            return message;
        }
        
        internal IClient GetClient(string clientName)
        {
            var client = clients.Select(clientName);
            return client;
        }
    }
}