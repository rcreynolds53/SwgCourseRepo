using System;
using SGBank.Models;

namespace SGBank.UI
{
    public class ConsoleIO
    {
      public static void DisplayAccountDetails(Account account)
        {
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Name: {account.Name}");
            Console.WriteLine($"Balance: {account.Balance:c}");
        }
    }
}
