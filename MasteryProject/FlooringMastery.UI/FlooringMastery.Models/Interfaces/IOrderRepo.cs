using System;
using System.Collections.Generic;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Models
{
    public interface IOrderRepo
    {
        void UpdateOrdersList(List<Order> orders, DateTime date);
		void CommitThisOrder(Order order);
        void RemoveThisOrder(Order order);
        Order GetOrder(DateTime date, int orderNumber);
        List<Order> GetAllOrdersForDate(DateTime userDate);
        void UpdateThisOrder(Order order);
    }
}
