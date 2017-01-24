using System;

namespace BankService.Domain
{
    internal abstract class Operation
    {
        private readonly DateTime date;
        private readonly int amount;

        protected Operation(DateTime valueDate, int valueAmount)
        {
            date = valueDate;
            amount = valueAmount;
        }

        internal virtual int GetAmount()
        {
            return amount;
        }

        //protected virtual string GetDate()
        //{
        //    return date.ToString("d");
        //}

        //public new abstract string ToString();
    }
}