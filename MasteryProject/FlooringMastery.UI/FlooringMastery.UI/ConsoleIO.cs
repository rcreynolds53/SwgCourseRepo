using System;
using System.Collections.Generic;
using FlooringMastery.Models.Responses;
using System.Linq;

namespace FlooringMastery.UI
{
    public class ConsoleIO
    {
        public static void DisplayOrderSummary(Order order)
        {
            Console.Clear();
            Console.WriteLine($"{order.OrderNumber} | {order.Date.ToShortDateString()}");
            Console.WriteLine($"{order.CustomerName}");
            Console.WriteLine($"{order.State}");
            Console.WriteLine($"Tax Rate: {order.TaxRate}");
			Console.WriteLine($"Product: {order.ProductType}");
            Console.WriteLine($"Area: {order.Area}");
			Console.WriteLine($"Cost Per Square Foot: {order.CostPerSquareFoot}");
            Console.WriteLine($"Labor Cost Per Square Foot: {order.LaborCostPerSquareFoot}");
            Console.WriteLine($"Materials: {order.MaterialCost:c}");
            Console.WriteLine($"Labor: {order.LaborCost:c}");
            Console.WriteLine($"Tax: {order.Tax:c}");
            Console.WriteLine($"Total: {order.Total:c}");
        }

        internal static void CancellationAborted()
        {
            Console.WriteLine("You decided to keep your existing order. Returning to main menu.");
        }

        internal static bool ConfirmOrderCancellation()
        {
            bool isCancelled = false;
			Console.WriteLine("Please review your order summary before cancelling your order.Are you sure you want to cancel your order?\nEnter Y to cancel your order or enter N to keep your order.");
			var userInput = Console.ReadLine();

			switch (userInput.ToUpper())
			{
				case "Y":
					isCancelled = true;
					break;
				case "N":
					isCancelled = false;
					break;
			}
			return isCancelled;
        }

        internal static string EditProductType(string productType)
        {
            Console.WriteLine("To edit the product please type in a new product:\n\nTo keep the product the same press enter.");
            string newProduct = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newProduct))
            {
                return productType;
            }
            else
            {
                Console.WriteLine($"{newProduct} has replace {productType}");
                Console.ReadKey();
                return (newProduct.First().ToString().ToUpper() + newProduct.Substring(1));
            }
        }

        internal static string EditState(string state)
        {
            Console.WriteLine("To edit the state please type in a new state:\n\nTo keep the state the same press enter.");
            string newState = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newState))
            {
                newState = state;
            }

            else
            {
                Console.WriteLine($"{newState} has replaced {state}");
                Console.ReadKey();
            }
            return newState.First().ToString().ToUpper() + newState.Substring(1);

		}

        internal static decimal EditArea(decimal area)
        {
			decimal newArea;
            while (true)
            {
                Console.WriteLine("To edit the area please type in a new area (minimum order 100 sq ft):\n\nTo keep the area the same press enter.");
                string userArea = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(userArea))
                {
                    return area;
                }

                if (!decimal.TryParse(userArea, out newArea))
                {
                    Console.WriteLine("Please enter a valid area.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    Console.WriteLine($"{newArea} has replace {area}");
					Console.ReadKey();
                    return newArea;
                }

            }
		}

        internal static string EditCustomerName(string customerName)
        {
            Console.WriteLine("To edit the name please type in a new customer name:\n\nTo keep the name the same press enter.");
            string newUserName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newUserName))
            {
                return customerName;
            }
            else
            {
                Console.WriteLine($"{newUserName} has replace {customerName}");
                Console.ReadKey();
                return newUserName;
            }
		}

        internal static void DisplayCustomerOrderDetails(Order editedOrder)
        {
                Console.Clear();
                Console.WriteLine($"{editedOrder.CustomerName}");
                Console.WriteLine($"{editedOrder.State}");
                Console.WriteLine($"Product: {editedOrder.ProductType}");
                Console.WriteLine($"Area: {editedOrder.Area}");
                Console.ReadLine();
            
        }

        internal static int GetOrderNumberFromUser()
        {
            while (true)
            {
                Console.WriteLine("Please enter the order number of the order you want to look up:");
                var userOrderNumber = Console.ReadLine();
                if (!int.TryParse(userOrderNumber, out int orderNumber))
                {
                    Console.WriteLine($"{userOrderNumber} is not a valid order number.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    return orderNumber;
                }
            }
        }

        internal static void DisplayProductsToUser(List<Product> products)
        {
			Console.Clear();
            foreach (var product in products)
            {
                Console.WriteLine($"Product Type: {product.ProductType}");
                Console.WriteLine($"Cost Per Square Foot: {product.CostPerSquareFoot}");
                Console.WriteLine($"Labor Cost Per Square Foot: {product.LaborCostPerSqaureFoot}");
                Console.WriteLine("");

            }
        }

        internal static decimal GetAreaFromUser()
        {
			while (true)
            {
                decimal area;
                Console.WriteLine("Please enter the area of material you want (minimum order size of 100 sq ft).");
                string areaFromUser = Console.ReadLine();
                if(!decimal.TryParse(areaFromUser, out area))
                {
                    Console.WriteLine($"{areaFromUser} is not a valid area.");
					Console.WriteLine("Press any key to continue...");
					Console.ReadKey();
					continue;
                }
                else
                {
                    return area;
                }
            }
        }

        internal static string GetProductFromUser()
        {
            while (true)
            {   
                Console.WriteLine();
                Console.WriteLine("Please enter the product you want to purchase.");
                var productType = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(productType))
                {
                    Console.WriteLine($"{productType} is not a valid product.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    return (productType.First().ToString().ToUpper() + productType.Substring(1));
                }
            }
        }

        internal static string GetStateFromUser()
        {
            while (true)
            {
                Console.WriteLine("Please enter your state.");
                var state = Console.ReadLine().Substring(0,1).ToUpper();

                if (string.IsNullOrWhiteSpace(state))
                {
                    Console.WriteLine("That is not a valid state.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    return state.First().ToString().ToUpper() + state.Substring(1);
                }
            }
        }

        internal static void OrderPlacedMessage()
        {
			Console.WriteLine("Your order has been placed! To look up your order, you will need to know the date and order number.");
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
        }

        internal static void OrderCancelledMessage()
        {
			Console.WriteLine("Your order has been canceled.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

		}
        internal static bool ConfirmOrderPlacement()
        {
            bool isValid = false;
            Console.WriteLine("Please review your order summary before placing your order.\nTo place your order enter Y, to cancel your order enter N.");
            var userInput = Console.ReadLine();

            switch(userInput.ToUpper())
            {
                case "Y":
                    isValid = true;
                    break;
                case "N":
                    isValid = false;
                    break;
            }
            return isValid;
        }

        internal static  string GetNameFromUser()
        {
            while(true)
            {
                Console.WriteLine("Please enter you name.");
                var customerName = Console.ReadLine();

                if(string.IsNullOrWhiteSpace(customerName))
                {
                    Console.WriteLine("That is not a valid name.");
					Console.WriteLine("Press any key to continue...");
					Console.ReadKey();
					continue;
                }
                else
                {
                    return customerName;
                }
            }
        }

        internal static DateTime GetDateFromUser()
        {
            while (true)
            {
                DateTime date;
                Console.WriteLine("Enter the order date in the format MM/dd/yyyy; or press q to return to the main menu");
                var userInput = Console.ReadLine();

                if (!DateTime.TryParseExact(userInput, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date))
                {
                    Console.WriteLine("That is not a valid order date.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    return date;
                }

            }


        }

        internal static void ValidateDateFormat()
        {
            throw new NotImplementedException();
            //while (true)
            //{
            //    Console.WriteLine("Enter the date of the order in the format MM/dd/yyyy.");
            //    string userInput = Console.ReadLine();

            //    //if()
            //}

        }

        internal static void DisplayOrdersToUser(List<Order> orders)
        {
            Console.Clear();
            foreach (var order in orders)
            {
                Console.WriteLine();
                Console.WriteLine($"{order.OrderNumber} | {order.Date.ToShortDateString()}");
                Console.WriteLine($"{order.CustomerName}");
                Console.WriteLine($"{order.State}");
                Console.WriteLine($"Product: {order.ProductType}");
                Console.WriteLine($"Materials: {order.MaterialCost:c}");
                Console.WriteLine($"Labor: {order.LaborCost:c}");
                Console.WriteLine($"Tax: {order.Tax:c}");
                Console.WriteLine($"Total: {order.Total:c}");
            }
        }
    }
}
