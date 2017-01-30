using BankApplication.Model;

namespace BankApplication.Domain.Transaction
{
    internal sealed class Debit : TransactionBase
    {
        private readonly int amount;

        internal Debit(Operation operation) : base(operation.Date())
        {
            amount = -operation.Amount();
        }

        internal override int Amount()
        {
            return amount;
        }

        internal override string Statement()
        {
            return $"{Date()} - Debit - {-amount}";
        }

        internal override TransactionStatus IsValid(int balance)
        {
            if (amount > 0)
            {
                return TransactionStatus.InvalidOperation;
            }

            if (balance + amount < 0)
            {
                return TransactionStatus.InsufficientFund;
            }

            return TransactionStatus.Success;
        }
    }
}