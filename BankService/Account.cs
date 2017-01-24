using System;
using BankService.Domain;
using BankServiceModel;
using BankServiceModel.Interfaces;

namespace BankService
{
    public class Account : IAccount
    {
        private readonly AccountOperations operations;

        public Account()
        {
            operations = new AccountOperations();
        }

        public MessageServiceType Deposit(DateTime date, int amount)
        {
            var operation = new Deposit(date, amount);
            AddOperation(operation);

            return MessageServiceType.Success;
        }

        public MessageServiceType Withdrawal(DateTime date, int amount)
        {
            var balance = GetBalanceAccount();
            if (balance < amount)
            {
                return MessageServiceType.InsufficientFund;
            }
            
            var operation = new Withdrawal(date, amount);
            AddOperation(operation);

            return MessageServiceType.Success;
        }

        public MessageServiceType Transfert(IAccount account, DateTime date, int amount)
        {
            var message = Withdrawal(date, amount);

            return message == MessageServiceType.InsufficientFund
                ? message
                : account.Deposit(date, amount);
        }

        public int GetBalanceAccount()
        {
            return operations.GetBalance();
        }

        private void AddOperation(Operation operation)
        {
            operations.Add(operation);
        }
    }
}