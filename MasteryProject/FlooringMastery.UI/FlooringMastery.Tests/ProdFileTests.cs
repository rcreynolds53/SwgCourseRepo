using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using FlooringMastery.Data;
using FlooringMastery.Data.TestRepos;
using FlooringMastery.Models.Responses;
using FlooringMastery.BLL;
using FlooringMastery.Data.ProdRepos;

namespace FlooringMastery.Tests
{
    [TestFixture]
    public class ProdFileTests
    {
        private string _filepath = "/Data/System.IO/Orders_09262018.txt";
        private string _ogData = "/Data/System.IO/Orders_09262018Test.txt";
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
        public void CanReadOrderFromFile()
        {
            Order order = new Order();
            ProdOrderRepository prodOrderRepo = new ProdOrderRepository();
            order.Date = DateTime.Parse("09/26/2018");
            var orders = prodOrderRepo.GetAllOrdersForDate(order.Date);

            Assert.AreEqual(4, orders.Count);

            Order orderToCheck = orders[1];

            Assert.AreEqual("Rob", orderToCheck.CustomerName);

        }
        [Test]
        public void CanAddOrderToFile()
        {
            Order order = new Order();
            ProdOrderRepository prodOrderRepo = new ProdOrderRepository();
            ProdProductRepository prodProductRepo = new ProdProductRepository();
            ProdTaxRepository prodTaxRepo = new ProdTaxRepository();
            order.Date = DateTime.Parse("09/26/2018");
            order.CustomerName = "Bill";
            order.State = "Michigan";
            order.ProductType = "Wood";
            order.Area = 100M;
            prodOrderRepo.CommitThisOrder(order);

            var orders = prodOrderRepo.GetAllOrdersForDate(order.Date);

            Assert.AreEqual(5, orders.Count);

        }
        [Test]
        public void CanEditOrderFromFile()
        {
            Order order = new Order();
            ProdOrderRepository prodOrderRepo = new ProdOrderRepository();
            order.Date = DateTime.Parse("09/26/2018");
            order.OrderNumber = 1;
            var orderToEdit = prodOrderRepo.GetOrder(order.Date, order.OrderNumber);
            order.CustomerName = "Tommy";
            order.ProductType = "Laminate";
            order.Area = 600;
            order.State = "Pennsylvania";
            prodOrderRepo.UpdateThisOrder(order);
            var orders = prodOrderRepo.GetAllOrdersForDate(order.Date);
            Assert.AreEqual(4, orders.Count);
            var editedOrder = orders[0];
            Assert.AreEqual("Tommy", editedOrder.CustomerName);
            Assert.AreEqual("Pennsylvania", editedOrder.State);
            Assert.AreEqual(600, editedOrder.Area);
            Assert.AreEqual("Laminate", editedOrder.ProductType);
        }

        [Test]
        public void CanRemoveOrderFromFile()
        {
            Order order = new Order();
            ProdOrderRepository prodOrderRepo = new ProdOrderRepository();
            order.Date = DateTime.Parse("09/26/2018");
            order.OrderNumber = 1;
            var orderToRemove = prodOrderRepo.GetOrder(order.Date, order.OrderNumber);
            prodOrderRepo.RemoveThisOrder(order);

            var orders = prodOrderRepo.GetAllOrdersForDate(order.Date);

            Assert.AreEqual(3, orders.Count);
        }
    }
}

