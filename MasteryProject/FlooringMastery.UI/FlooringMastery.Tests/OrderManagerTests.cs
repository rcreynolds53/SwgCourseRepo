using System;
using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.Data.TestRepos;
using FlooringMastery.Models.Responses;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace FlooringMastery.Tests
{
    [TestFixture]
    public class OrderManagerTests
    {
        [TestCase("09/21/2017", "Bill Parcels", "Indiana", "Carpet", 100, false, 0)]
        [TestCase("09/19/2017", "Bill Parcels", "Minnesota", "Carpet", 100, false, 0)]
        [TestCase("09/22/2017", "Bill Parcels", "Michigan", "Carpet", 99, false, 0)]
        [TestCase("09/22/2017", "Bill Parcels", "Michigan", "Brick", 100, false, 0)]
        [TestCase("09/22/2018", "Bill Parcels", "Michigan", "Carpet", 100, true, 1)]
        public void OrderManagerAddOrderTest(DateTime date, string customerName, string state, string productType, decimal area, bool expectedResult, int expectedCount)

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
            if (response.Success)
            {
                testOrderRepo.CommitThisOrder(response.Order);

                Assert.AreEqual(expectedCount, testOrderRepo.GetAllOrdersForDate(date).Count);
            }
        }

        [TestCase("09/21/2017", 1,"Bill Parcels", "Indiana", "Carpet", 100,  "Rob", "Michigan", "Brick", 150, false)]
        [TestCase("09/21/2017", 1,"Bill Parcels", "Indiana", "Carpet", 100,  "Rob", "Texas",  "Tile", 150, false)]
        [TestCase("09/21/2017", 1,"Bill Parcels", "Indiana", "Carpet", 100,  "Rob", "Michigan", "Tile", 99, false)]
		[TestCase("09/21/2017", 1, "Bill Parcels", "Indiana", "Carpet", 100, "Rob", "Michigan", "Tile", 150, true)]

		public void OrderManagerEditOrderTest(DateTime date, int orderNumber, string customerName, string state, string productType, decimal area, string expectedName, string expectedState, string expectedProduct, decimal expectedArea, bool expectedResult)
        {
			TestOrderRepository testOrderRepo = new TestOrderRepository();
			TestProductRepository testProductRepo = new TestProductRepository();
			TestTaxRepository testTaxRepo = new TestTaxRepository();
			OrderManager manager = new OrderManager(testOrderRepo, testProductRepo, testTaxRepo);
            DisplaySingleOrderResponse singleResponse = manager.GetOrderToEdit(date, orderNumber);

            Assert.AreEqual(singleResponse.Order.Date, date);
            Assert.AreEqual(singleResponse.Order.OrderNumber, orderNumber);
            Assert.AreEqual(singleResponse.Order.CustomerName, customerName);
            Assert.AreEqual(singleResponse.Order.State, state);
            Assert.AreEqual(singleResponse.Order.ProductType, productType);
            Assert.AreEqual(singleResponse.Order.Area, area);


			EditOrderResponse response = manager.EditOrder(date, orderNumber, expectedName, expectedState, expectedProduct,expectedArea);

			// DisplaySingleOrderResponse afterEditResponse = manager.GetOrderToEdit(date, orderNumber);
			if (response.Success)
            {
				testOrderRepo.UpdateThisOrder(response.Order);
				DisplaySingleOrderResponse afterEditResponse = manager.GetOrderToEdit(date, orderNumber);

				Assert.AreEqual(afterEditResponse.Order.Date, date);
                Assert.AreEqual(afterEditResponse.Order.OrderNumber, orderNumber);
                Assert.AreEqual(afterEditResponse.Order.CustomerName, expectedName);
                Assert.AreEqual(afterEditResponse.Order.State, expectedState);
                Assert.AreEqual(afterEditResponse.Order.ProductType, expectedProduct);
                Assert.AreEqual(afterEditResponse.Order.Area, expectedArea);

			}
            //testOrderRepo.UpdateThisOrder(response.Order);
            //Assert.AreEqual(expectedResult,


        }
    }
}

