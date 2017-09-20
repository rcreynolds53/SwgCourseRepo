using System;
using System.Collections.Generic;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Models
{
    public interface IOrderRepo
    {
        List<Order> LoadOrdersList(string filePath);
		void EditOrder(Order orderToEdit, int index);
		void AddOrder(Order ordertoAdd);
        void RemoveOrder(Order ordertoRemove);
        void SaveThisOrder(Order order);
        //string CreateCsvForOrder(Order order);
        //void CreateOrderFile(List<Order> orders);
    }
}
