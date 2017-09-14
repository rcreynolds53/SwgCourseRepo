using System;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.BLL.DepositRules
{
    public class FreeAccountDepositRule : IDeposit
    {

        public AccountDepositResponse Deposit(Account account, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();
            if (account.Type != AccountType.Free)
            {
                response.Success = false;
                response.Message = "Error: a non free account hit the Free Deposit Rule, Contact IT.";
                return response;
            }
            if(amount > 100)
            {
                response.Success = false;
                response.Message = "Error: free accounts can not deposit more than $100 at a time.";
                return response;
            }

            if(amount <=0)
            {
                response.Success = false;
                response.Message = "Error: deposit amounts must be greater than zero.";
                return response;
            }

            response.OldBalance = account.Balance;
            account.Balance += amount;
            response.Account = account;
            response.AmountDeposited = amount;
            response.Success = true;
            return response;
        }
        
    }
}
