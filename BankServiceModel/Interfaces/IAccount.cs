using System;

namespace BankServiceModel.Interfaces
{
    public interface IAccount
    {
        MessageServiceType Deposit(DateTime date, int amount);

        MessageServiceType Withdrawal(DateTime date, int amount);

        MessageServiceType Transfert(IAccount account, DateTime convertDate, int amount);

        int GetBalanceAccount();
    }
}