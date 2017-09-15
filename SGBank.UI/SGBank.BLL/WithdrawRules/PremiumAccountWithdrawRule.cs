using System;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.BLL.WithdrawRules
{
    public class PremiumAccountWithdrawRule : IWithdraw
    {

        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            if(account.Type != AccountType.Premium)
            {
                response.Success = false;
                response.Message = "Error: a non-premium account hit the Premium Withdraw Rule. Contact IT";
                return response;
            }
            if(amount > 0)
            {
                response.Success = false;
                response.Message = "Withdrawal amount must be negative.";
                return response;
            }
            if(account.Balance+ amount <-500)
            {
                response.Success = false;
                response.Message = "Premium accounts cannot overdraft more than $500.";
                return response;
            }
            response.Success = true;
            response.Account = account;
            response.OldBalance = account.Balance;
            response.Amount = amount;
            account.Balance += amount;
            return response;


        }
    }
}
