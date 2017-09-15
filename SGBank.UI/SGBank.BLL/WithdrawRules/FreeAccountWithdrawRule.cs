﻿using System;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.BLL.WithdrawRules
{
    public class FreeAccountWithdrawRule : IWithdraw
    {
        public FreeAccountWithdrawRule()
        {
        }

        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            if(account.Type != AccountType.Free)
            {
                response.Success = false;
                response.Message = "Error: a non-free account hit the Free Withdraw Rule. Contact IT";
                return response;
            }
            if(amount >= 0)
            {
                response.Success = false;
                response.Message = "Withdrawal amount must be negative.";
                return response;
            }
            if( amount < -100)
            {
                response.Success = false;
                response.Message = "Free acounts cannot withdraw more than $100.";
                return response;
            }
            if( account.Balance + amount < 0)
            {
                response.Success = false;
                response.Message = "Free accounts cannot overdraft.";
                return response;
            }

            response.Success = true;
            response.Account = account;
            response.Amount = amount;
            response.OldBalance = account.Balance;
            account.Balance += amount;
            return response;

        }
    }
}
