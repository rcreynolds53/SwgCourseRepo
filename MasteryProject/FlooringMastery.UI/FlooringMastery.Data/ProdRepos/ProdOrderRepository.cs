using System;
using System.Collections.Generic;
using System.IO;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Data
{
    public class ProdOrderRepository : IOrderRepo
    {
        public string _filePath;
        public void AddOrder(Order ordertoSave)
        {
            throw new NotImplementedException();
        }

        public void EditOrder(Order orderToEdit, int index)
        {
            var orders = LoadOrdersList(_filePath);
        }

        public void RemoveOrder(Order ordertoRemove)
        {
            throw new NotImplementedException();
        }

        public void SaveThisOrder(Order order)
        {
            using(StreamWriter sw = new StreamWriter(_filePath))
            {
                
            }
        }

        public List<Order> LoadOrdersList(string filePath)
        {
            List<Order> orders = new List<Order>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
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

                    orders.Add(newOrder);
                }
                return orders;
            }
        }

        public string CreateCsvForOrder(Order order)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", order.OrderNumber, order.CustomerName, order.State, order.TaxRate, order.ProductType, order.Area, order.CostPerSquareFoot, order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.Tax, order.Total);
        }

        public void CreateOrderFile(List<Order> orders)
        {
            if(File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

        }
    }
}
