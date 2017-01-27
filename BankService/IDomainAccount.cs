using System;
using BankApplication.Model;
using BankApplication.Model.Interface;

namespace BankApplication.Domain
{
    public interface IDomainAccount
    {
        BankMessage DepositFromAccount(IAccount sender, DateTime date, int amount);
    }
}