using System;
using System.Collections.Generic;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Data
{
    public class ProdOrderRepository : IOrder
    {
        public ProdOrderRepository()
        {
        }
        private static Order _order = new Order();

		public List<Order> LoadOrdersList()
		{
			throw new NotImplementedException();
		}

        public void RemoveOrder(Order ordertoRemove)
        {
            throw new NotImplementedException();
        }

        public void SaveOrder(Order ordertoSave)
        {
            _order = ordertoSave;
        }
    }
}
