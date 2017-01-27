using System;
using BankApplication.Domain.Operation.Base;
using BankApplication.Model;

namespace BankApplication.Domain.Operation
{
    internal class Withdrawal : BaseOperation
    {   
        internal Withdrawal(DateTime date, int amount) : base(date, amount)
        {      
        }

        internal override int Amount()
        {
            return -base.Amount();
        }

        internal override BankMessage Allowed(int balance)
        {
            return new BankMessage(CheckStatus(balance), $"{Date()} - {OperationType.Withdrawal} - {Amount()}");
        }

        protected BankStatus CheckStatus(int balance)
        {
            if (balance + Amount() < 0)
            {
                return BankStatus.InsufficientFund;
            }

            return BankStatus.Success;
        }
    }
}