using System;
using FlooringMastery.BLL;

namespace FlooringMastery.UI.Workflows
{
    public class RemoveOrderWorkflow
    {
        internal void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Console.Clear();
            Console.WriteLine("Remove an Order");
			Console.WriteLine("------------------------------------");
			DateTime date = ConsoleIO.GetDateFromUser();
			int orderNumber = ConsoleIO.GetOrderNumberFromUser();
            var orderToRemove = manager.GetOrderToEdit(date, orderNumber);
            if (!orderToRemove.Success)
            {
                Console.WriteLine(orderToRemove.Message);
                Console.ReadKey();
                return;
            }
            else
            {
                ConsoleIO.DisplayOrderSummary(orderToRemove.Order);
                Console.ReadKey();
                if (!ConsoleIO.ConfirmOrderCancellation())
                {
                    ConsoleIO.CancellationAborted();
                }
                manager.RemoveThisOrder(orderToRemove.Order);
                ConsoleIO.OrderCancelledMessage();
            }
		}
    }
}
