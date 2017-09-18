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
    public class FreeAccountTest
    {
        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("12345");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("12345", response.Account.AccountNumber);
        }
        //fail too much deposited
        [TestCase("12345", "Free Account", 100, AccountType.Free, 250, false)]
        //fail, negative number 
		[TestCase("12345", "Free Account", 100, AccountType.Free, -100, false)]
        // fail, not a free account
        [TestCase("12345", "Free Account", 100, AccountType.Basic, 50, false)]
        //sucess
		[TestCase("12345", "Free Account", 100, AccountType.Free, 50, true)]
		public void FreeAccountDepositRuleTest(string accountNumber, string name, decimal balance, 
                                               AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit depositRule = new FreeAccountDepositRule();
            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Balance = balance;
            account.Type = accountType;
            account.Name = name;

            AccountDepositResponse response = depositRule.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);

        }
        [TestCase("12345", "Free Account", 100, AccountType.Basic, -50, 50 ,false)]
        //fail, negative number 
        [TestCase("12345", "Basic Account", 100, AccountType.Free, -101, -1 ,false)]
        // fail, not a free account
        [TestCase("12345", "Free Account", 100, AccountType.Free, -50, 50 ,true)]
        //sucess
        [TestCase("12345", "Free Account", 100, AccountType.Free, 100, 0, false)]
        [TestCase("12345", "Free Account", 50, AccountType.Free, -60, -10 ,false)]

        public void FreeAccountWithdrawRuleTest(string accountNumber, string name, decimal balance,
                                                AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {

            IWithdraw withdrawRule = new FreeAccountWithdrawRule();
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
