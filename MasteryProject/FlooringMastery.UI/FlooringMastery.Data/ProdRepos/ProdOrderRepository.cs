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

        public void EditOrder(Order order)
		{
            throw new NotImplementedException();

        }

        public void UpdateOrdersList(List<Order> orders, DateTime date)
        {
            if (File.Exists(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt",date)))
            {
                File.Delete(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", date));
            }
            using (StreamWriter writer = new StreamWriter(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", date )))
            {
                writer.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total,Date");
                foreach (var o in orders)
                {
                    writer.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", o.OrderNumber, o.CustomerName, o.State, o.TaxRate, o.ProductType, o.Area, o.CostPerSquareFoot, o.LaborCostPerSquareFoot, o.MaterialCost, o.LaborCost, o.Tax, o.Total));
                }
            }
        }

        public string CreateCsvForOrder(Order order)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", order.OrderNumber, order.CustomerName, order.State, order.TaxRate, order.ProductType, order.Area, order.CostPerSquareFoot, order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.Tax, order.Total);
        }

        public Order GetOrder(DateTime date, int orderNumber)
        {
            List<Order> orders = new List<Order>();
            orders = GetAllOrdersForDate(date);
            var orderToGet = orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
            return orderToGet;
        }

        public List<Order> GetAllOrdersForDate(DateTime userDate)
        {

			List<Order> orders = new List<Order>();
            try
            {
                using (StreamReader reader = new StreamReader(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", userDate)))
                {
                    reader.ReadLine();
                    string line;

                    while ((line = reader.ReadLine()) != null)
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
                        newOrder.Date = userDate;

                        orders.Add(newOrder);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occured reading the file: {ex.Message}");
                Console.WriteLine($"The error occured at: {ex.StackTrace}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
			return orders.OrderBy(o => o.OrderNumber).ToList();
		}

        public void CommitThisOrder(Order order)
        {
            
            using(StreamWriter writer = new StreamWriter(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", order.Date), true))
            {
                writer.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", order.OrderNumber, order.CustomerName, order.State, order.TaxRate, order.ProductType, order.Area, order.CostPerSquareFoot, order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.Tax, order.Total));
      
			}
        }

        public void UpdateThisOrder(Order order)
        {
			List<Order> orders = GetAllOrdersForDate(order.Date);

			var orderToRemove = orders.Single(o => o.OrderNumber == order.OrderNumber);
			orders.Remove(orderToRemove);
            orders.Add(order);

			UpdateOrdersList(orders, order.Date);
        }

        public void RemoveThisOrder(Order order)
        {
            List<Order> orders = GetAllOrdersForDate(order.Date);

            var orderToRemove = orders.Single(o => o.OrderNumber == order.OrderNumber);
            orders.Remove(orderToRemove);

            UpdateOrdersList(orders, order.Date);


        }


    }
}
