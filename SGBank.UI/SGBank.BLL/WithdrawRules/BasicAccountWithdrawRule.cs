using System;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.BLL.WithdrawRules
{
    public class BasicAccountWithdrawRule : IWithdraw
    {
        public BasicAccountWithdrawRule()
        {
        }

        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            if(account.Type != AccountType.Basic)
            {
                response.Success = false;
                response.Message = "Error: a non basic account hit the Basic Withdraw Rule. Contact IT";
                return response;
            }

            if(amount > 0)
            {
                response.Success = false;
                response.Message = "Withdrawal amounts must be negative.";
                return response;
            }
            if(amount < -500)
            {
                response.Success = false;
                response.Message = "Basic accounts cannot withdraw more than $500.";
                return response;
            }
            if(account.Balance + amount< -100)
            {
                response.Success = false;
                response.Message = "Basic accounts cannot overdraft more than $100.";
                return response;
            }
            //if ((account.Balance += amount) < 0)
            //{
            //    response.Success = true;
            //    response.Account = account;
            //    response.OldBalance = account.Balance;
            //    response.Amount = amount;
            //    account.Balance += amount - 10;
            //    response.Message = $"Withdrawal successful; you overdrafted and your account was charged a $10 fee.";
            //    return response;
            //}
			response.Success = true;
			response.Account = account;
			response.OldBalance = account.Balance;
			response.Amount = amount;
            account.Balance += amount;
			if (account.Balance + amount < 0)
			{
			    account.Balance += -10;
			response.Message = "Withdrawal successful; you overdrafted and your account was charged a $10 fee.";

			}
			return response;
        }
    }
}
