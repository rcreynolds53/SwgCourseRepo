﻿using System;
using SGBank.Models;
using SGBank.Models.Interfaces;

namespace SGBank.Data
{
    public class BasicAccountTestRepository : IAccountRepository
    {
        private static Account _account = new Account
        {
            Name = "Basic Account",
            AccountNumber = "33333",
            Balance = 100M,
            Type = AccountType.Basic
        };
        public Account LoadAccount(string accountNumber)
        {
            if(accountNumber != _account.AccountNumber)
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
