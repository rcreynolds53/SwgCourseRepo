using System;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Data
{
    public class TestOrderRepository : IOrderRepo
    {
        private static Order _order = new Order()
        {
            Date = DateTime.Parse("9/20/2017"),
            OrderNumber = 1,
            CustomerName = "Bill Parcels",
            State = "MI",
            TaxRate = 6.00M,
            ProductType = "Carpet",
            Area = 100M,
            CostPerSquareFoot = 2.25M,
            LaborCostPerSquareFoot = 2.10M,

        };

        public void AddOrder(Order ordertoSave)
        {
            throw new NotImplementedException();
        }

        public void EditOrder(Order orderToEdit)
        {
            throw new NotImplementedException();
        }

        public void LoadOrdersList()
        {
            throw new NotImplementedException();
        }

        public void RemoveOrder(Order ordertoRemove)
        {
            throw new NotImplementedException();
        }

        public void SaveThisOrder(Order order)
        {
            _order = order;
        }
    }
}
