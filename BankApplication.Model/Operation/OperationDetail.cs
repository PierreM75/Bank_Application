namespace BankApplication.Model.Operation
{
    public class OperationDetail
    {
        private readonly OperationType operationType;
        private readonly int balance;

        public OperationDetail(OperationType operationType, int balance)
        {
            this.operationType = operationType;
            this.balance = balance;
        }

        public OperationType OperationType()
        {
            return operationType;
        }

        public int Balance()
        {
            return balance;
        }
    }
}