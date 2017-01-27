using System;
using BankApplication.Domain.Operation.Base;
using BankApplication.Model;
using BankApplication.Model.Interface;

namespace BankApplication.Domain.Operation
{
    internal class TransfertAsWithdrawal : Withdrawal
    {
        private readonly IClient receiver;
        
        public TransfertAsWithdrawal(IClient receiver, DateTime date, int amount) : base(date, amount)
        {
            this.receiver = receiver;
        }
        
        internal override BankMessage Allowed(int balance)
        {
            return new BankMessage(CheckStatus(balance), $"{Date()} - {OperationType.Transfer} to {receiver.Name()} - {Amount()}");
        }
    }
}