using System;
using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.Data.TestRepos;
using FlooringMastery.Models.Responses;
using NUnit.Framework;
namespace FlooringMastery.Tests
{
    [TestFixture]
    public class OrderManagerTests
    {
        [TestCase("09/21/2017", 1, "Bill Parcels", "Indiana", 6.00, "Carpet", 100, 2.25, 2.10, false)]
		[TestCase("09/19/2017", 1, "Bill Parcels", "Minnesota", 6.00,"Carpet", 100, 2.25, 2.10, false)]
		[TestCase("09/22/2017", 1, "Bill Parcels", "Michigan", 5.75, "Carpet", 99, 2.25, 2.10, false)]
		[TestCase("09/22/2017", 1, "Bill Parcels", "Michigan", 6.00, "Brick", 100, 2.25, 2.10, false)]
		[TestCase("09/22/2017", 1, "Bill Parcels", "Michigan", 5.75, "Carpet", 100, 2.25, 2.10, true)]


		public void OrderManagerAddOrderTest(DateTime date, int orderNumber, string customerName,
                                             string state, decimal taxRate, string productType,
                                             decimal area, decimal costPerSqFt, decimal laborCostPerSqFt, bool expectedResult)

        {
            TestOrderRepository testOrderRepo = new TestOrderRepository();
            TestProductRepository testProductRepo = new TestProductRepository();
            TestTaxRepository testTaxRepo = new TestTaxRepository();
            OrderManager addOrderRule = new OrderManager(testOrderRepo, testProductRepo, testTaxRepo);
            AddOrderResponse response = addOrderRule.BuildNewOrder(date, customerName, state, productType, area);
			//Order order = new Order();

			//order.Date = date;
			//order.OrderNumber = orderNumber;
			//order.CustomerName = customerName;
			//order.State = state;
			//order.TaxRate = taxRate;
			//order.ProductType = productType;
			//order.Area = area;
			//order.CostPerSquareFoot = costPerSqFt;
			//order.LaborCostPerSquareFoot = laborCostPerSqFt;

			Assert.AreEqual(expectedResult, response.Success);
        }
    }
}
