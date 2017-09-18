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
        private const string _filepath = "/Users/macbookpro/Documents/SG-Bootcamp/dotnet-rob-reynolds/SGBank.UI/SGBank.UI/bin/Debug/AccountsTest.txt";
        private const string _ogData = "/Users/macbookpro/Documents/SG-Bootcamp/dotnet-rob-reynolds/SGBank.UI/SGBank.UI/bin/Debug/AccountsTestSeed.txt";
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
            FileAccountRepository repo = new FileAccountRepository();
            Assert.AreEqual(3, repo._account.Count);

        }

        public FilePathTests()
        {
        }
    }
}
