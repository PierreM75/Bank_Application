namespace BankApplication.Model
{
    public class BankMessage
    {
        private readonly BankStatus status;
        private readonly string label;

        public BankMessage(BankStatus status, string label)
        {
            this.status = status;
            this.label = label;
        }

        public BankStatus Status()
        {
            return status;
        }

        public string Label()
        {
            return label;
        }
    }
}
