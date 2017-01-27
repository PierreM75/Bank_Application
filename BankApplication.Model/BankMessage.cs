namespace BankApplication.Model
{
    public class BankMessage
    {
        private readonly BankStatus status;
        private readonly string message;

        public BankMessage(BankStatus status, string message)
        {
            this.status = status;
            this.message = message;
        }

        public BankStatus Status()
        {
            return status;
        }

        public string Message()
        {
            return message;
        }
    }
}
