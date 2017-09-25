using System;
using System.Collections.Generic;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System.Linq;
using System.Diagnostics.Contracts;

namespace FlooringMastery.Data
{
    public class TestOrderRepository : IOrderRepo
    {
        private static List<Order> _orders = new List<Order>
        {
            new Order
            {
            Date = DateTime.Parse("9/20/2017"),
            OrderNumber = 1,
            CustomerName = "Bill Parcels",
            State = "Michigan",
            TaxRate = 5.75M,
            ProductType = "Carpet",
            Area = 100M,
            CostPerSquareFoot = 2.25M,
            LaborCostPerSquareFoot = 2.10M,
            },
            new Order
            {
				Date = DateTime.Parse("9/21/2017"),
			OrderNumber = 1,
			CustomerName = "Bill Parcels",
			State = "Indiana",
			TaxRate = 6.00M,
			ProductType = "Carpet",
			Area = 100M,
			CostPerSquareFoot = 2.25M,
			LaborCostPerSquareFoot = 2.10M,
            },
			new Order
			{
				Date = DateTime.Parse("9/21/2017"),
			OrderNumber = 2,
			CustomerName = "Billy Parcels",
			State = "Indiana",
			TaxRate = 6.00M,
			ProductType = "Tile",
			Area = 100M,
			CostPerSquareFoot = 3.50M,
			LaborCostPerSquareFoot = 4.15M,
			},

        };

        public void CommitThisOrder(Order order)
        {
            _orders.Add(order);
        }

        public List<Order> GetAllOrdersForDate(DateTime userDate)
        {
            return _orders.Where(d=>d.Date == userDate).OrderBy(o=>o.OrderNumber).ToList();
        }

        public Order GetOrder(DateTime date, int orderNumber)
        {
            return GetAllOrdersForDate(date).FirstOrDefault(o => o.OrderNumber == orderNumber);       
        }

        public void UpdateOrdersList(List<Order> orders, DateTime date)
        {
            _orders = orders;  
        }

        public void RemoveThisOrder(Order order)
        {
			Order orderToRemove = GetOrder(order.Date, order.OrderNumber);
            _orders.Remove(orderToRemove);
		}

        public void UpdateThisOrder(Order order)
        {
            Order ogOrder = GetOrder(order.Date, order.OrderNumber);

            _orders.Remove(ogOrder);
            _orders.Add(order);

            //_orders.OrderBy(o=>o.OrderNumber);


        }
    }
}
