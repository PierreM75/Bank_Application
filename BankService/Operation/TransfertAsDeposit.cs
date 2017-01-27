using System;
using BankApplication.Domain.Operation.Base;
using BankApplication.Model;
using BankApplication.Model.Interface;

namespace BankApplication.Domain.Operation
{
    internal class TransfertAsDeposit: Deposit
    {
        private readonly IClient sender;
        
        internal TransfertAsDeposit(IClient sender, DateTime date, int amount) : base(date, amount)
        {
            this.sender = sender;
        }

        internal override BankMessage Allowed(int balance)
        {
            return new BankMessage(BankStatus.Success, $"{Date()} - {OperationType.Transfer} from {sender.Name()} - {Amount()}");
        }
    }
}