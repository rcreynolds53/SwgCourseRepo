using System;
using System.Collections.Generic;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Models
{
    public interface IOrderRepo
    {
        List<Order> LoadOrdersList();
		void EditOrder(Order order);
		void CommitThisOrder(Order order);
        //void RemoveOrder(int orderNumber);
        //void SaveOrders(List<Order> orders);
        Order GetOrder(DateTime date, int orderNumber);
        List<Order> GetAllOrdersForDate(DateTime userDate);
        void UpdateThisOrder(Order order);
        //string CreateCsvForOrder(Order order);
        //void CreateOrderFile(List<Order> orders);
    }
}
