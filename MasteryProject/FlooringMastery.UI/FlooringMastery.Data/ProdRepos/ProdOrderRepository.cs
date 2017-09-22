using System;
using System.Collections.Generic;
using System.IO;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System.Linq;

namespace FlooringMastery.Data
{
    public class ProdOrderRepository : IOrderRepo
    {
        public List<Order> _orders = new List<Order>();
        public string _filePath;

//        public void AddOrder(Order ordertoSave)
//        {
//using()    
            //}

        public void EditOrder(Order order)
		{
            throw new NotImplementedException();
            //order = GetOrder(order.OrderNumber);
            //SaveOrders(_orders);
        }

        public void RemoveOrder(int orderNumber)
        {
            throw new NotImplementedException();
            //var orders = LoadOrdersList(_filePath);
            //var ordertoRemove = orders.First(o => o.OrderNumber == orderNumber);
            //orders.Remove(ordertoRemove);
            //SaveOrders(orders);
        }

        //public void SaveThisOrder(Order order)
        //{
        //    using(StreamWriter sw = new StreamWriter(_filePath,true))
        //    {
        //        string line = CreateCsvForOrder(order);
        //        sw.WriteLine(line);
        //    }
        //}

        public List<Order> LoadOrdersList()
        {
            //List<Order> orders = new List<Order>();
            if (File.Exists(_filePath))
            {

                using (StreamReader sr = new StreamReader(_filePath))
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

                        _orders.Add(newOrder);
                    }
                }
            }
            return _orders;
        }


        public string CreateCsvForOrder(Order order)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", order.OrderNumber, order.CustomerName, order.State, order.TaxRate, order.ProductType, order.Area, order.CostPerSquareFoot, order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.Tax, order.Total);
        }


        //public void SaveOrders(List<Order> orders)
        //{
        //    if(File.Exists(_filePath))
        //        File.Delete(_filePath);
            
        //    using(StreamWriter sw = new StreamWriter(_filePath))
        //    {
        //        sw.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
        //        foreach(var order in orders)
        //        {
        //            sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", order.OrderNumber, order.CustomerName, order.State, order.TaxRate, order.ProductType, order.Area, order.CostPerSquareFoot, order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.Tax, order.Total));
        //        }
        //    }
        //}

        public Order GetOrder(DateTime date, int orderNumber)
        {
            throw new NotImplementedException();
            //_orders = LoadOrdersList(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", date));
            //var orderToGet = _orders.First(o => o.OrderNumber == orderNumber);
            //return orderToGet;
        }

        public List<Order> GetAllOrdersForDate(DateTime userDate)
        {
            throw new NotImplementedException();
        }

        public void CommitThisOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void UpdateThisOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
