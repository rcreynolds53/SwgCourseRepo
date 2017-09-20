using System;
using System.Collections.Generic;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System.IO;

namespace FlooringMastery.Data
{
    public class TestOrderRepositorymock : IOrderRepo
    {
        private string _filePath; //= "/Users/macbookpro/Documents/SG-Bootcamp/dotnet-rob-reynolds/MasteryProject/FlooringMastery.UI/FlooringMastery.UI/bin/Debug/Orders_06012013.txt";
        private Order _order = new Order();

		public TestOrderRepositorymock(string filePath)
		{
            _filePath = filePath;
		}

        public void AddOrder(Order ordertoSave)
        {
            throw new NotImplementedException();
        }

        public void EditOrder(Order orderToEdit)
        {
            throw new NotImplementedException();
        }

        public List<Order> LoadOrdersList()
        {
            List<Order> orders = new List<Order>();
            using(StreamReader sr = new StreamReader(_filePath))
            {
                sr.ReadLine();
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    Order newOrder = new Order();
                    string[] columns = line.Split(',');
                    newOrder.OrderNumber = int.Parse(columns[0]);
                    newOrder.CustomerName = columns[1];
                    newOrder.State = columns[2];
                    newOrder.TaxRate = decimal.Parse(columns[3]);
                    newOrder.ProductType = columns[4];
                    newOrder.Area = decimal.Parse(columns[5]);
                    newOrder.CostPerSquareFoot = decimal.Parse(columns[6]);
                    newOrder.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                    //newOrder.MaterialCost = decimal.Parse(columns[8]);
                    //newOrder.LaborCost = decimal.Parse(columns[9]);
                    //newOrder.Tax = decimal.Parse(columns[10]);
                    //newOrder.Total = decimal.Parse(columns[11]);

                    orders.Add(newOrder);
                }
                return orders;
            }

        }

        public void RemoveOrder(Order ordertoRemove)
        {
            throw new NotImplementedException();
        }

        public void SaveOrder(Order ordertoSave)
        {
            _order = ordertoSave;
        }

        public void SaveThisOrder(Order order)
        {
            throw new NotImplementedException();
        }

        void IOrderRepo.LoadOrdersList()
        {
            throw new NotImplementedException();
        }
    }
}
