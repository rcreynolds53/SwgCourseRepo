using System;
using System.Collections.Generic;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Models
{
    public interface IOrderRepo
    {
        List<Order> LoadOrdersList();
        void SaveOrder(Order ordertoSave);
        void RemoveOrder(Order ordertoRemove);
    }
}
