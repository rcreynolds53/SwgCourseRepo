using System;
using SGBank.BLL;
using SGBank.Models.Responses;

namespace SGBank.UI.Workflows
{
    public class WithdrawWorkflow
    {
       public void Execute()
        {
            AccountManager accountManager = AccountManagerFactory.Create();
            Console.WriteLine("Enter an account number: ");
            string accountNumber = Console.ReadLine();
            decimal amount;

            while (true)
            {
                Console.WriteLine("Enter an amount to withdraw: ");
                if (!decimal.TryParse(Console.ReadLine(), out amount))
                {
                    continue;
                }
                amount *= -1;
                break;
            }
            AccountWithdrawResponse response = accountManager.Withdraw(accountNumber, amount);

            if(response.Success)
            {
                Console.WriteLine("Withdrawal was successful!");
                Console.WriteLine($"Account Number: {response.Account.AccountNumber}");
                Console.WriteLine($"Old Balance: {response.OldBalance:c}");
                Console.WriteLine($"Withdrawal Amount: {response.Amount:c}");
                Console.WriteLine($"New Balance: {response.Account.Balance:c}");
            }
            else
            {
                Console.WriteLine("An error occured: ");
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("Press any key to conintue...");
            Console.ReadKey();
        }
    }
}
