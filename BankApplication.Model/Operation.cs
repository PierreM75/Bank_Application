using System;

namespace BankApplication.Model
{
    public class Operation
    {
        private readonly int amount;
        private readonly DateTime date;

        public Operation(DateTime date, int amount)
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