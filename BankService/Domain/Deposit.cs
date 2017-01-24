using System;

namespace BankService.Domain
{
    internal class Deposit : Operation
    {
        private readonly OperationType operationType;

        internal Deposit(DateTime date, int amount) : base(date, amount)
        {
            operationType = OperationType.Deposit;
        }

        //public override string ToString()
        //{
        //    return $"{GetDate()} {operationType} {GetAmount()}";
        //}
    }
}