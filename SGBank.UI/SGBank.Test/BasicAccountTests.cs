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
    public class BasicAccountTests
    {
        [TestCase("33333", "Basic Account", 100, AccountType.Free, 250, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -100, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 250, true)]

		public void BasicAccountDepositRulesTest(string accountNumber, string name,
                                                 decimal balance, AccountType accountType,
                                                decimal amount, bool expectedResult)

        {
            IDeposit depositRule = new NoLimitDepositRule();
            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Type = accountType;
            account.Balance = balance;

            AccountDepositResponse response = depositRule.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }
		[TestCase("33333", "Basic Account", 1500, AccountType.Basic, -1000, 1500, false)]
		[TestCase("33333", "Basic Account", 100, AccountType.Free, -100, 100, false)]
		[TestCase("33333", "Basic Account", 100, AccountType.Basic, 100, 100, false)]
		[TestCase("33333", "Basic Account", 150, AccountType.Basic, -50, 100, true)]
		[TestCase("33333", "Basic Account", 100, AccountType.Basic, -150, -60, true)]


		public void BasicAccountWithdrawRulesTest(string accountNumber, string name,
										 decimal balance, AccountType accountType,
										decimal amount,decimal expectedBalance,
                                        bool expectedResult)
        {
            IWithdraw withdrawRule = new BasicAccountWithdrawRule();
            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;
            AccountWithdrawResponse response = withdrawRule.Withdraw(account,amount);
            if (response.Success)
            {
                Assert.AreEqual(expectedBalance, response.Account.Balance);
            }
            Assert.AreEqual(expectedResult, response.Success);


        }
                                                 


	}
}
