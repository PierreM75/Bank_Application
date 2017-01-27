using BankApplication.Model;

namespace BankApplication.Domain.Operation
{
    internal sealed class Credit : BaseOperation
    {
        private readonly int amount;
        internal Credit(OperationDetail operation) : base(operation.Date())
        {
            amount = operation.Amount();
        }

        internal override int Amount()
        {
            return amount;
        }

        internal override BankMessage IsAllowed(int balance)
        {
            return new BankMessage(CheckStatus(amount), $"{Date()} - Credit - {amount}");
        }
    }
}