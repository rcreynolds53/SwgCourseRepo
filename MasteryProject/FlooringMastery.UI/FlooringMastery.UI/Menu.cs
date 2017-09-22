using System;
using FlooringMastery.UI.Workflows;

namespace FlooringMastery.UI
{
    public class Menu
    {
        public void Start()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("****************************************************");
                Console.WriteLine();
                Console.WriteLine("* Flooring Program");
                Console.WriteLine("*");
                Console.WriteLine("* 1. Display Orders");
                Console.WriteLine("* 2. Add an Order");
                Console.WriteLine("* 3. Edit an Order");
                Console.WriteLine("* 4. Remove an Order");
                Console.WriteLine("* 5. Quit");
                Console.WriteLine("*");
                Console.WriteLine();
                Console.WriteLine("****************************************************");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        DisplayOrderWorkflow displayWorkflow = new DisplayOrderWorkflow();
                        displayWorkflow.Execute();
                        break;
                    case "2":
                        AddOrderWorkflow addWorkflow = new AddOrderWorkflow();
                        addWorkflow.Execute();
                        break;
                    case "3":
                        EditOrderWorkflow editWorkflow = new EditOrderWorkflow();
                        editWorkflow.Execute();
                        break;
                    case "4":
                        RemoveOrderWorkflow removeWorkflow = new RemoveOrderWorkflow();
                        removeWorkflow.Execute();
                        break;
                    case "5":
                        return; 
                }
            }
		}
    }
}
