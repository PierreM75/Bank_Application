using System;

namespace BankApplication.Model
{
    public class OperationDetail
    {
        private readonly DateTime date;
        private readonly int amount;

        public OperationDetail(DateTime date, int amount)
        {
            this.date = date;
            this.amount = amount;
        }

        public DateTime Date()
        {
            return date;
        }

        public int Amount()
        {
            return amount;
        }
    }
}