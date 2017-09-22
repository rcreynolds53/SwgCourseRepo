using System;
using FlooringMastery.BLL;
using System.Linq;
using FlooringMastery.Models.Responses;
using System.Collections.Generic;

namespace FlooringMastery.UI.Workflows
{
    public class EditOrderWorkflow
    {
        internal void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Edit an Order");
            Console.WriteLine("------------------------------------");
            DateTime date = ConsoleIO.GetDateFromUser();
            int orderNumber = ConsoleIO.GetOrderNumberFromUser();
            var orderToEdit = manager.GetOrderToEdit(date, orderNumber);
            if (!orderToEdit.Success)
            {
                Console.WriteLine(orderToEdit.Message);
                Console.ReadKey();
                return;
            }
            ConsoleIO.DisplayCustomerOrderDetails(orderToEdit.Order);
            string editedCustomerName = ConsoleIO.EditCustomerName(orderToEdit.Order.CustomerName);
			ConsoleIO.DisplayCustomerOrderDetails(orderToEdit.Order);
            string editedState = ConsoleIO.EditState(orderToEdit.Order.State);
            ConsoleIO.DisplayCustomerOrderDetails(orderToEdit.Order);
			List<Product> products = manager.GetAllProducts();
			ConsoleIO.DisplayProductsToUser(products);
            string editedProductType = ConsoleIO.EditProductType(orderToEdit.Order.ProductType);
            ConsoleIO.DisplayCustomerOrderDetails(orderToEdit.Order);
            decimal editedArea = ConsoleIO.EditArea(orderToEdit.Order.Area);
            DateTime keepOrderDate = orderToEdit.Order.Date;
            int keepOrderNumber = orderToEdit.Order.OrderNumber;
			EditOrderResponse response = manager.EditOrder(keepOrderDate, keepOrderNumber,editedCustomerName,editedState,editedProductType,editedArea);

            if (!response.Success)
            {
                Console.WriteLine(response.Message);
                Console.ReadKey();
            }
            else
            {
                ConsoleIO.DisplayOrderSummary(response.Order);
                Console.ReadKey();
                if (!ConsoleIO.ConfirmOrderPlacement())
                {
                    ConsoleIO.OrderCancelledMessage();
                }
                else
                {
                    manager.UpdateThisOrder(response.Order);
                    ConsoleIO.OrderPlacedMessage();
                }



            }
        }
    }
}
