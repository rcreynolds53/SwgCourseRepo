using System;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.BLL.DepositRules
{
    public class NoLimitDepositRule : IDeposit
    {
        public AccountDepositResponse Deposit(Account account, decimal amount)
        {
			AccountDepositResponse response = new AccountDepositResponse();

            if((account.Type != AccountType.Basic) &&(account.Type != AccountType.Premium))
            {
                response.Success = false;
                Console.WriteLine("Error: only basic and premium accounts can deposit with no limit. Contact IT");
                return response;
            }

            if(amount <=0)
            {
                response.Success = false;
                response.Message = $"Deposits must be positive.";
                return response;
            }
            response.Success = true;
            response.Account = account;
            response.OldBalance = account.Balance;
            response.AmountDeposited = amount;
            account.Balance += amount;
            return response;
		}
    }
}
