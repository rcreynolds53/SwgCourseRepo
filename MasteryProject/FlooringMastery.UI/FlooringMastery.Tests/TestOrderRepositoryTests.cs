using System;
using System.Collections.Generic;
using System.IO;
using FlooringMastery.Data;
using FlooringMastery.Models.Responses;
using NUnit.Framework;
namespace FlooringMastery.Tests
{
    [TestFixture]
    public class TestOrderRepositoryTests
    {
        public string _filePath = "/Users/macbookpro/Documents/SG-Bootcamp/dotnet-rob-reynolds/MasteryProject/FlooringMastery.UI/FlooringMastery.UI/bin/Debug/Orders_06012013.txt";
        public string _ogData = "/Users/macbookpro/Documents/SG-Bootcamp/dotnet-rob-reynolds/MasteryProject/FlooringMastery.UI/FlooringMastery.UI/bin/Debug/Orders_06012013Seed.txt";

        [SetUp]
        public void Setup()
        {
            if(File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
            File.Copy(_ogData, _filePath);
        }
        public void CanReadOrdersFromFile()
        {
            TestOrderRepository repo = new TestOrderRepository(_filePath);
            //List<Order> orders = repo.LoadOrdersList();

            Assert.AreEqual(1, orders.Count);

        }

		[TestCase(1, "Wise", "OH", 6.25, "Bronze", 100.00, 5.15, 4.75, 515.00, 475.00, 61.88, 1051.88, false)]
        public void DataReadInIsCorrect(int orderNumber, string customerName, string state, decimal taxRate,
                                        string productType, decimal area, decimal costPerSqFt, decimal laborCostPerSqFt,
                                        decimal materialCost, decimal laborCost, decimal tax, decimal total, bool expectedResult)
        {
            throw new NotImplementedException();
        }

    }
}
