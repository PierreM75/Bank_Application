using System;
using BankApplication.Domain.Operation;
using BankApplication.Model;
using BankApplication.Model.Interface;

namespace BankApplication.Domain
{
    public class Account: IDomainAccount, IAccount
    {
        private readonly OperationList operations = new OperationList();

        public BankMessage Deposit(DateTime date, int amount)
        {
            return operations.Execute(new Deposit(date, amount));
        }

        public BankMessage Withdrawal(DateTime date, int amount)
        {
            return operations.Execute(new Withdrawal(date, amount));
        }

        public BankMessage Transfert(IAccount receiver, DateTime date, int amount)
        {
            var message = operations.Execute(new TransfertAsWithdrawal((IClient)receiver, date, amount));
            if (message.Status() == BankStatus.InsufficientFund)
            {
                return message;
            }
            
            ((IDomainAccount) receiver).DepositFromAccount(this, date, amount);
            return message;
        }

        public BankMessage DepositFromAccount(IAccount sender, DateTime date, int amount)
        {
            return operations.Execute(new TransfertAsDeposit((IClient)sender, date, amount));
        }

        public int Balance()
        {
            return operations.Balance();
        }
    }
}