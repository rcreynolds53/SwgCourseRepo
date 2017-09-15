using System;
using SGBank.Models;
using SGBank.Models.Interfaces;

namespace SGBank.Data
{
    public class PremiumAccountTestRepository : IAccountRepository
    {
        private static Account _account = new Account
        {
            Name = "Premium Account",
            AccountNumber = "11111",
            Balance = 150M,
            Type = AccountType.Premium,
        };
        public Account LoadAccount(string accountNumber)
        {
            if (accountNumber != _account.AccountNumber)
            {
                return null;
            }
            return _account;

        }

        public void SaveAccount(Account account)
        {
            _account = account;
        }
    }
}
