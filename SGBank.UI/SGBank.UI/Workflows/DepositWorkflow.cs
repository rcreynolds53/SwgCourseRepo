﻿using System;
using SGBank.BLL;
using SGBank.Models.Responses;

namespace SGBank.UI.Workflows
{
    public class DepositWorkflow
    {
       public void Execute()
        {
            AccountManager accountManager = AccountManagerFactory.Create();

            Console.WriteLine("Enter an account number: ");
            string accountNumber = Console.ReadLine();

            decimal amount;

            while(true)
            {
				Console.WriteLine("Enter a deposit amount: ");

				if(!decimal.TryParse(Console.ReadLine(), out amount))
                {
                    continue;
                }
                break;
            }

            AccountDepositResponse response = accountManager.Deposit(accountNumber, amount);

            if(response.Success)
            {
                Console.WriteLine("Deposit completed!");
                Console.WriteLine($"Account Number: {response.Account.AccountNumber}");
                Console.WriteLine($"Old balance: {response.OldBalance:c}");
                Console.WriteLine($"Amount Depositied: {response.AmountDeposited:c}");
                Console.WriteLine($"New Balance: {response.Account.Balance:c}");

            }
            else
            {
                Console.WriteLine("An error occured: ");
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}
