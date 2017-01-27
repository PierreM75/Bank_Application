using BankApplication.Model;

namespace BankApplication.Domain.Operation
{
    internal sealed class Debit : BaseOperation
    {
        private readonly int amount;

        internal Debit(OperationDetail operation) : base(operation.Date())
        {   
            this.amount = operation.Amount();
        }

        internal override int Amount()
        {
            return -amount;
        }

        internal override BankMessage IsAllowed(int balance)
        {
            return new BankMessage(CheckStatus(balance), $"{Date()} - Debit - {amount}");
        }

        protected override BankStatus CheckStatus(int balance)
        {
            if (balance + Amount() < 0)
            {
                return BankStatus.InsufficientFund;
            }

            return base.CheckStatus(amount);
        }
    }
}