using System;
using NUnit.Framework;
using SGBank.BLL;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
namespace SGBank.Test
{
    [TestFixture]
    public class PremiumAccountTests
    {
        // first two false ( wrong account, cant deposit negative) third true;
        [TestCase("11111", "Premium Account", 150, AccountType.Free, 250, false)]
        [TestCase("11111", "Premium Account", 150, AccountType.Premium, -100, false)]
		[TestCase("11111", "Premium Account", 150, AccountType.Premium, 100, true)]
        public void PremiumAccountDepositRuleTest(string accountNumber, string name,
                                                  decimal balance, AccountType accountType,
                                                 decimal amount, bool expectedResult)
        {
            IDeposit depositRule = new NoLimitDepositRule();
            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountDepositResponse response = depositRule.Deposit(account, amount);

            Assert.AreEqual(expectedResult,response.Success);
        }
        // false; wrong AccountType 
        [TestCase("11111", "Premium Account", 500, AccountType.Basic, -1000, -500, false)]
        // cant withdraw positive amount 
		[TestCase("11111", "Premium Account", 500, AccountType.Premium, 1000, 1500, false)]
        //false;  cant overdraft more than 500
		[TestCase("11111", "Premium Account", 500, AccountType.Premium, -1500, -1000, false)]
		//test true
		[TestCase("11111", "Premium Account", 500, AccountType.Premium, -1000, -500, true)]
        //true
		[TestCase("11111", "Premium Account", 700, AccountType.Premium, -600, 100, true)]

        public void PremiumAccountWithdrawRule(string accountNumber,string name,
                                               decimal balance, AccountType accountType,
                                               decimal amount, decimal newBalance,
                                               bool expectedResult)
        {
            IWithdraw withdrawRule = new PremiumAccountWithdrawRule();
            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountWithdrawResponse response = withdrawRule.Withdraw(account, amount);

            if (response.Success)
                newBalance = response.Account.Balance;
            Assert.AreEqual(expectedResult, response.Success);

        }

	}
}
