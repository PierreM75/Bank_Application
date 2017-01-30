namespace BankApplication.Model
{
    public class TransactionMessage
    {
        private readonly string label;
        private readonly TransactionStatus status;

        public TransactionMessage(TransactionStatus status, string label)
        {
            this.status = status;
            this.label = label;
        }

        public TransactionStatus Status()
        {
            return status;
        }

        public string Label()
        {
            return label;
        }
    }
}