using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using SGBank.Data;
using SGBank.Models;

namespace SGBank.Test
{
    [TestFixture]
    public class FilePathTests
    {
        private  string _filepath = "/Users/macbookpro/Documents/SG-Bootcamp/dotnet-rob-reynolds/SGBank.UI/SGBank.UI/bin/Debug/AccountsTest.txt";
        private  string _ogData = "/Users/macbookpro/Documents/SG-Bootcamp/dotnet-rob-reynolds/SGBank.UI/SGBank.UI/bin/Debug/AccountsTestSeed.txt";
        [SetUp]
        public void Setup()
        {
            if (File.Exists(_filepath))
            {
                File.Delete(_filepath);
            }
            File.Copy(_ogData, _filepath);
        }
        [Test]
        public void CanReadAccountFromFile()
        {
            FileAccountRepository repo = new FileAccountRepository("/Users/macbookpro/Documents/SG-Bootcamp/dotnet-rob-reynolds/SGBank.UI/SGBank.UI/bin/Debug/AccountsTest.txt");
            List<Account> accounts = repo._account;
            Assert.AreEqual(3, accounts.Count);

            Account accountToCheck = accounts[1];

            Assert.AreEqual("22222", accountToCheck.AccountNumber);
            Assert.AreEqual("Basic Customer", accountToCheck.Name);
            Assert.AreEqual(500, accountToCheck.Balance);
            Assert.AreEqual("Basic", accountToCheck.Type.ToString());
        }
    }
}
