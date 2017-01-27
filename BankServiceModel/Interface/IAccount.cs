using System;

namespace BankApplication.Model.Interface
{
    public interface IAccount
    {
        BankMessage Deposit(DateTime date, int amount);

        BankMessage Withdrawal(DateTime date, int amount);

        BankMessage Transfert(IAccount receiver, DateTime date, int amount);

        int Balance();
    }
}