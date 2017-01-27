using System;
using BankApplication.Model;

namespace BankApplication.Domain.Operation.Base
{
    internal abstract class BaseOperation
    {
        private readonly DateTime date;
        private readonly int amount;

        protected BaseOperation(DateTime date, int amount)
        {
            this.date = date;
            this.amount = amount;
        }

        internal virtual int Amount()
        {
            return amount;
        }

        internal abstract BankMessage Allowed(int balance);

        protected string Date()
        {
            return date.ToString("dd-MM-yyyy");
        }
    }
}