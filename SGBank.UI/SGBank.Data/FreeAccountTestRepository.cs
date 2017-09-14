using System;
using SGBank.Models;
using SGBank.Models.Interfaces;

namespace SGBank.Data
{
    public class FreeAccountTestRepository : IAccountRepository
    {
        private static Account _account = new Account
        {
            Name = "Free Account",
            AccountNumber = "12345",
            Balance = 100.00M,
            Type = AccountType.Free
        };
        public Account LoadAccount(string AccountNumber)
        {
            return _account;
        }

        public void SaveAccount(Account account)
        {
            _account = account;
        }
    }
}
