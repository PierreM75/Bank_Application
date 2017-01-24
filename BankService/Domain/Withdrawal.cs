using System;

namespace BankService.Domain
{
    internal class Withdrawal : Operation
    {
        private readonly OperationType operationType;

        internal Withdrawal(DateTime date, int amount) : base(date, amount)
        {
            operationType = OperationType.Withdrawal;
        }

        internal override int GetAmount()
        {
            var amount = base.GetAmount();
            return -amount;
        }

        //public override string ToString()
        //{
        //    return $"{GetDate()} {operationType} {GetAmount()}";
        //}
    }
}