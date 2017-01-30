using BankApplication.Model;

namespace BankApplication.Domain.Transaction
{
    internal sealed class Credit : TransactionBase
    {
        private readonly int amount;

        internal Credit(Operation operation) : base(operation.Date())
        {
            amount = operation.Amount();
        }

        internal override int Amount()
        {
            return amount;
        }

        internal override string Statement()
        {
            return $"{Date()} - Credit - {amount}";
        }

        internal override TransactionStatus IsValid(int balance)
        {
            if (amount < 0)
            {
                return TransactionStatus.InvalidOperation;
            }

            return TransactionStatus.Success;
        }
    }
}