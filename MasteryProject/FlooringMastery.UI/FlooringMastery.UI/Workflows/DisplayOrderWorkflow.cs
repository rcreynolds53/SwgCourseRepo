using System;
using FlooringMastery.BLL;
using FlooringMastery.Models.Responses; 

namespace FlooringMastery.UI.Workflows
{
    public class DisplayOrderWorkflow
    {
        public DisplayOrderWorkflow()
        {
        }

        internal void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Display Orders");
            Console.WriteLine("------------------------------------");
            DateTime userDate = ConsoleIO.GetDateFromUser();

            DisplayOrdersResponse response = manager.GetAllOrdersForDate(userDate);

            if (!response.Success)
            {
                Console.WriteLine(response.Message);
            }
            else
            {
                ConsoleIO.DisplayOrdersToUser(response.Orders);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
