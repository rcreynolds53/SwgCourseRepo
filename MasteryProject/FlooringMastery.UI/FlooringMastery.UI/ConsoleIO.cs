using System;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.UI
{
    public class ConsoleIO
    {
        public void DisplayOrderSummary(Order order)
        {
            Console.WriteLine($"{order.OrderNumber} | {order.Date}");
            Console.WriteLine($"{order.CustomerName}");
            Console.WriteLine($"{order.State}");
            Console.WriteLine($"Product: {order.ProductType}");
            Console.WriteLine($"Materials: {order.MaterialCost}");
            Console.WriteLine($"Labor: {order.LaborCost}");
            Console.WriteLine($"Tax: {order.Tax}");
            Console.WriteLine($"Total: {order.Total}");
		}
    }
}
