using System;
using BankApplication.Model;

namespace BankApplication.Domain.Transaction
{
    internal abstract class TransactionBase
    {
        private readonly DateTime date;

        protected TransactionBase(DateTime date)
        {
            this.date = date;
        }

        internal abstract int Amount();

        protected string Date()
        {
            return date.ToString("dd/MM/yyyy");
        }

        internal abstract TransactionStatus IsValid(int balance);

        internal abstract string Statement();
    }
}