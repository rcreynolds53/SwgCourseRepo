using System;
using System.Collections.Generic;
using FlooringMastery.BLL;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.UI.Workflows
{
    public class AddOrderWorkflow
    {
        internal void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
			//AddOrderResponse response = manager.BuildNewOrder(userDate, customerName, state, productType, area);

			Console.Clear();
			Console.WriteLine("Add an Order");
			Console.WriteLine("------------------------------------");
			DateTime userDate = ConsoleIO.GetDateFromUser();
            string customerName = ConsoleIO.GetNameFromUser();
            string state = ConsoleIO.GetStateFromUser();
            List<Product> products = manager.GetAllProducts();
            ConsoleIO.DisplayProductsToUser(products);
            string productType = ConsoleIO.GetProductFromUser();
            decimal area = ConsoleIO.GetAreaFromUser();

            AddOrderResponse response = manager.BuildNewOrder(userDate, customerName, state, productType, area);

            if (!response.Success)
            {
                Console.WriteLine(response.Message);
            }
            else
            {
                ConsoleIO.DisplayOrderSummary(response.Order);
                Console.ReadKey();
                if(!ConsoleIO.ConfirmOrderPlacement())
                {
                    ConsoleIO.OrderCancelledMessage();
                }
                else
                {
                    manager.CommitOrder(response.Order);
                    ConsoleIO.OrderPlacedMessage();
                }
            }

        }
    }
}
