using System;
using System.Collections.Generic;
using BankApplication.Domain;
using BankApplication.Model;
using BankApplication.Model.Filter;
using BankApplication.Model.Interface;
using BankApplication.Model.Operation;

namespace BankApplication.Tests
{
    internal class BankApplicationContext
    {
        private readonly IClients clients = new Clients();
        private TransactionStatus status;

        internal void CreateClientAccount(string clientName, int amount, string date)
        {
            var client = new Client(clientName);
            clients.Create(client);
            status = client.Deposit(new Operation(date.ConvertDate(), amount));
        }

        internal void Deposit(string clientName, int amount, string date)
        {
            status = ClientByName(clientName).Deposit(new Operation(date.ConvertDate(), amount));
        }

        internal void Withdrawal(string clientName, int amount, string date)
        {
            var operation = new Operation(date.ConvertDate(), amount);
            status = ClientByName(clientName).Withdrawal(operation);
        }

        internal void Transfert(string fromClientName, string toClientName, int amount, string date)
        {
            var fromClient = ClientByName(fromClientName);
            var toClient = ClientByName(toClientName);
            var operation = new Operation(date.ConvertDate(), amount);
            status = fromClient.Transfert(toClient, operation);
        }

        internal int Balance(string clientName)
        {
            return ClientByName(clientName).Balance();
        }

        internal TransactionStatus Status()
        {
            return status;
        }

        internal IClient ClientByName(string clientName)
        {
            var client = clients.Select(clientName);
            return client;
        }

        internal IEnumerable<Statement> Statements(string clientName)
        {
            return ClientByName(clientName).Statements(
                new PeriodFilter(DateTime.MinValue, DateTime.MaxValue), 
                new AmountFilter());
        }
    }
}