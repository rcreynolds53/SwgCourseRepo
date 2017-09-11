using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();
            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5();
            //Exercise6();
            //Exercise7();
            //Exercise8();
            //Exercise9();
            //Exercise10();
            //Exercise11();
            //Exercise12();
            //Exercise13();
            //Exercise14();
            //Exercise15(); 
            //Exercise16();
            //Exercise17();
            //Exercise18();
            //Exercise19();
            //Exercise20();
            //Exercise22();
            //Exercise23();
            //Exercise24();
            //Exercise25();
            //Exercise26();
            //Exercise27();
            //Exercise28();
            //Exercise29();
            //Exercise30();
            //Exercise31();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            var filter = DataLoader.LoadProducts().Where(p => p.UnitsInStock < 1);
            PrintProductInformation(filter);

            //query syntax

            var Products = DataLoader.LoadProducts();

            var findZero = from product in Products
                           where product.UnitsInStock == 0
                           select product;
            PrintProductInformation(findZero);

        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            // filter out all the products whose cost is less than 3.01

            var minCost = DataLoader.LoadProducts().Where(p => p.UnitPrice > 3.00M).Where(p => p.UnitsInStock > 0);
            PrintProductInformation(minCost);

            //query syntax 
            var Products = DataLoader.LoadProducts();

            var inStockCost3 = from product in Products
                               where product.UnitPrice > 3.00M
                               where product.UnitsInStock > 0
                               select product;
            PrintProductInformation(inStockCost3);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            var customersInWA = DataLoader.LoadCustomers().Where(c => c.Region == "WA");
            PrintCustomerInformation(customersInWA);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            var products = from p in DataLoader.LoadProducts()
                           select new
                           {
                               PName = p.ProductName,
                           };
            Console.WriteLine("{0,-15}", "Product Name");
            Console.WriteLine();
            foreach (var productRow in products)
            {
                Console.WriteLine("{0,-15}", productRow.PName);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            var allProducts = from p in DataLoader.LoadProducts()
                              select new
                              {
                                  PID = p.ProductID,
                                  PName = p.ProductName,
                                  PCategory = p.Category,
                                  PUnitPrice = (p.UnitPrice * 1.25M),
                                  PUnitsInStock = p.UnitsInStock
                              };
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in allProducts)
            {
                Console.WriteLine("{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}", product.PID, product.PName, product.PCategory, product.PUnitPrice, product.PUnitsInStock);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            var allUpper = from p in DataLoader.LoadProducts()
                           select new
                           {
                               PName = p.ProductName.ToUpper(),
                               PCategory = p.Category.ToUpper(),
                           };
            Console.WriteLine("{0,-35} {1,-15}", "Product Name", "Category");
            Console.WriteLine("===========================================");

            foreach (var product in allUpper)
            {
                Console.WriteLine("{0,-35} {1,-15}", product.PName, product.PCategory);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            var stockNotThree = from p in DataLoader.LoadProducts()
                                select new
                                {
                                    PID = p.ProductID,
                                    PName = p.ProductName,
                                    PCategory = p.Category,
                                    PUnitPrice = p.UnitPrice,
                                    PUnitStock = p.UnitsInStock,
                                    PReorder = p.UnitsInStock < 3 ? "true" : "false",
                                };
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,8} {5,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "Reorder");
            Console.WriteLine("====================================================================================");

            foreach (var product in stockNotThree)
            {
                Console.WriteLine("{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5,6}", product.PID, product.PName, product.PCategory
                                  , product.PUnitPrice, product.PUnitStock, product.PReorder);
            }

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            var products = from p in DataLoader.LoadProducts()
                           select new
                           {
                               PID = p.ProductID,
                               PName = p.ProductName,
                               PCategory = p.Category,
                               PUnitPrice = p.UnitPrice,
                               PUnitStock = p.UnitsInStock,
                               PStockValue = p.UnitPrice * p.UnitsInStock,
                           };
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,10} {5,12}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "Stockvalue");
            Console.WriteLine("=======================================================================================");

            foreach (var product in products)
            {
                Console.WriteLine("{0,-5} {1,-35} {2,-15} {3,6:c} {4,10} {5,12}", product.PID, product.PName, product.PCategory,
                                  product.PUnitPrice, product.PUnitStock, "$" + product.PStockValue);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            var newNumbersA = DataLoader.NumbersA.Where(numbers => numbers % 2 == 0);

            foreach (var number in newNumbersA)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {

            var order = DataLoader.LoadCustomers().Where(c => c.Orders.Any(cust => cust.Total < 500M));

            PrintCustomerInformation(order);

        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var FirstThreeOdd = DataLoader.NumbersC.Where(num => num % 2 == 1).Take(3);
            foreach(var num in FirstThreeOdd)
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var skipFirstThree = DataLoader.NumbersB.Skip(3);

            foreach(var num in skipFirstThree)
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
			var InWash= from customer in DataLoader.LoadCustomers().Where(cust => cust.Region == "WA")
									select new
									{
										CompanyName = customer.CompanyName,
										FirstOrder = customer.Orders.OrderByDescending(c => c.OrderDate).First(),
									};

			Console.WriteLine("{0,-35} {1,-15}", "Company Name", "First Order");
			Console.WriteLine("===========================================");
			foreach (var cust in InWash)
			{
                Console.WriteLine("{0,-35} {1,-15}", cust.CompanyName, cust.FirstOrder.OrderID);
			}
        }
        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var printNum = DataLoader.NumbersC.TakeWhile(num => num < 6);
            foreach(var n in printNum)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            var newNumbersC = DataLoader.NumbersC.SkipWhile(n => n % 3 != 0).Skip(1);

            foreach(var n in newNumbersC)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            var ProductsOrdered = DataLoader.LoadProducts().OrderBy(p => p.ProductName);

            foreach(var p in ProductsOrdered)
            {
                Console.WriteLine(p.ProductName);
            }
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            var ProductsByReverseStock = from product in DataLoader.LoadProducts().OrderByDescending(p => p.UnitsInStock)
                                         select new
                                         {
                                             productName = product.ProductName,
                                             unitsInStock = product.UnitsInStock,

                                         };
            Console.WriteLine("{0,-35} {1,20}", "Product Name", "Units in Stock");
            Console.WriteLine("========================================================");
            foreach(var p in ProductsByReverseStock)
            {
                Console.WriteLine("{0,-35} {1,20}", p.productName, p.unitsInStock);

			}

        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            var ProductsByCat = from product in DataLoader.LoadProducts().OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice)
                                select new
                                {
                                    PName = product.ProductName,
                                    PCat = product.Category,
                                    PUnitPrice = product.UnitPrice,
                                };
            Console.WriteLine("{0,-35} {1,20} {2,20}", "Product Name", "Category", "Unit Price");
			Console.WriteLine("=============================================================================");

            foreach(var p in ProductsByCat)
            {
                Console.WriteLine("{0,-35} {1,20} {2,20}", p.PName, p.PCat, p.PUnitPrice);
            }
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var ReverseNumbersB = DataLoader.NumbersB.Reverse();
            foreach(var num in ReverseNumbersB)
                Console.WriteLine(num);
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            var groups =DataLoader.LoadProducts().GroupBy(p => p.Category);

            foreach(var p in groups)
            {
				Console.WriteLine();
				Console.WriteLine(p.Key);
                foreach(var product in p)
                {
                    Console.WriteLine(product.ProductName);
                }
            }

        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            //skip 

            throw new NotImplementedException();
        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {


            //this works simpler 

            var groups = DataLoader.LoadProducts().GroupBy(p => p.Category);

            foreach (var product in groups)
				{
                Console.WriteLine(product.Key);
				}

   //         var UniquePRoductCats = from category in DataLoader.LoadProducts().GroupBy(p => p.Category)
   //                                 select category.Key; 

			// Console.WriteLine("{0,-35}", "Category");
			//Console.WriteLine("=============================================");

            //foreach(var c in UniquePRoductCats)
            //{
            //    Console.WriteLine(c);
            //}

		}

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            var prodExist = DataLoader.LoadProducts().FirstOrDefault(p => p.ProductID == 789);

            Console.WriteLine(prodExist);
			if(prodExist == null)
			    Console.WriteLine($"The product you are looking for does not exist.");
			else
			Console.WriteLine($"Product id 789 is {prodExist.ProductName}.");

            //this works as well. 
			var prodExists = DataLoader.LoadProducts().Any(p => p.ProductID == 789) ? true : false;


}

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            var categories = DataLoader.LoadProducts().Where(p=>p.UnitsInStock == 0).GroupBy(c => c.Category);
            foreach(var c in categories)
            {
                Console.WriteLine(c.Key);
            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            // I need to group into categories 
            // Then check within those categories to see if any products have no units in stock 
            // If they do, I need to skip over them and go onto the next category 
            //var categories = DataLoader.LoadProducts().SkipWhile(p => p.UnitsInStock == 0).GroupBy(c => c.Category);

            var outOfStockCategories = DataLoader.LoadProducts().GroupBy(c => c.Category).Where(p => p.All(prod => prod.UnitsInStock != 0));

            //the followign code works too, a bit more work if you do not know how many to skip...

            //var outOfStockCategories2 = DataLoader.LoadProducts().GroupBy(c => c.Category).OrderBy(p => p.All(prod => prod.UnitsInStock != 0)).Skip(3);


			foreach(var c in outOfStockCategories)
            {
                Console.WriteLine(c.Key);
            }

            //Console.WriteLine();

        }
            /// <summary>
            /// Count the number of odd numbers in NumbersA
            /// </summary>
            static void Exercise26()
        {
            var oddNums = DataLoader.NumbersA.Count(n => n % 2 == 1);

            Console.WriteLine(oddNums);
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            var custOrders = from c in DataLoader.LoadCustomers()
                             select new

                             {
                                 CID = c.CustomerID,
                                 COrder = c.Orders.Count(),
                             };
            Console.WriteLine("{0,-20} {1,10}", "Customer ID", "Number of Orders");
			Console.WriteLine("====================================================");
            foreach(var c in custOrders)
            {
                Console.WriteLine("{0,-20} {1,10}", c.CID,c.COrder);
			}
		}

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
			var groups = DataLoader.LoadProducts().GroupBy(p => p.Category);

			foreach (var product in groups)
			{
				Console.WriteLine(product.Key);
                Console.WriteLine(product.Count());

            }        
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
			var groups = DataLoader.LoadProducts().GroupBy(p => p.Category);

			foreach (var product in groups)
			{
				Console.WriteLine(product.Key);
                Console.WriteLine("Total Units In Stock: " + product.Sum(p=>p.UnitsInStock));
				Console.WriteLine();

			}
		}

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            var categories = from categoryGroup in DataLoader.LoadProducts().GroupBy(c => c.Category)
                             select new
                             {

                                 ProdName = categoryGroup.OrderBy(prod => prod.UnitPrice).First(),
                                 CCat = categoryGroup.Key,
                                 CMin = categoryGroup.Min(prod => prod.UnitPrice)

                             };

            Console.WriteLine("{0,-30} {1,15} {2,15}", "Product Name", "Category", "Unit Price");
			Console.WriteLine("====================================================");
            foreach (var c in categories)
            {
                Console.WriteLine("{0,-30} {1,15} {2,15}", c.ProdName.ProductName, c.CCat, c.CMin);
            }
            // method syntax below

			//var test = DataLoader.LoadProducts().GroupBy(c => c.Category).Select(categoryGroup => new
			//{

			//    ProdName = categoryGroup.OrderBy(prod => prod.UnitPrice).First(),
			//    CCat = categoryGroup.Key,
			//    CMin = categoryGroup.Min(prod => prod.UnitPrice)

			//});

			//foreach(var p in categories)
			//        {
			//            Console.WriteLine(p.Key);
			//   Console.WriteLine($"Lowest Prices Product is {} ${p.Min(prod=>prod.UnitPrice)}");
			//Console.WriteLine();
			//         var groupProducts = from product in DataLoader.LoadProducts()
			//                             group product by product.Category into newGroup
			//                             select newGroup;
			//         foreach (var p in groupProducts)
			//{
			//	Console.WriteLine(p.Key);
			//             Console.WriteLine("Lowest Prices Product is: $" + p.Min(prod => prod.UnitPrice));
			//	Console.WriteLine();
			//}


		}

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            // Take the top 3 categories based on average. 1) Group By category 2) ** Do I order by decending first?** Average unit price 3) take 3 

            var averageCategory = DataLoader.LoadProducts().GroupBy(c => c.Category).OrderByDescending(p=>p.Average(c=>c.UnitPrice)).Take(3);

            foreach (var p in averageCategory)
            {
                Console.WriteLine(p.Key);
                Console.WriteLine("$" + p.Average(prod=>prod.UnitPrice));
            }
        }
    }
}