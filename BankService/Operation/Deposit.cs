using System;
using BankApplication.Domain.Operation.Base;
using BankApplication.Model;

namespace BankApplication.Domain.Operation
{
    internal class Deposit : BaseOperation
    {
        internal Deposit(DateTime date, int amount) : base(date, amount)
        {
        }
        
        internal override BankMessage Allowed(int balance)
        {
            return new BankMessage(BankStatus.Success, $"{Date()} - {OperationType.Deposit} - {Amount()}");
        }
    }
}