using System;
using BankApplication.Model;

namespace BankApplication.Domain.Operation
{
    internal abstract class BaseOperation
    {
        private readonly DateTime date;
        
        protected BaseOperation(DateTime date)
        {
            this.date = date;
        }

        internal abstract int Amount();

        internal abstract BankMessage IsAllowed(int balance);

        protected virtual BankStatus CheckStatus(int amount)
        {
            if (amount < 0)
            {
                return BankStatus.InvalidOperation;
            }

            return BankStatus.Success;
        }

        protected string Date()
        {
            return date.ToString("dd/MM/yyyy");
        }
    }
}