using System;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using FlooringMastery.Data;

namespace FlooringMastery.BLL
{
    public class OrderManager
    {
        public string _filePath;
        private IOrderRepo _orderRepo;
        private IProductRepo _productRepo;
        private ITaxRepo _taxRepo;

        public OrderManager(IOrderRepo orderRepo, IProductRepo productRepo, ITaxRepo taxRepo)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _taxRepo = taxRepo;

        }

        public void CreateOrderDate(DateTime userDate)
        {
            if (!File.Exists(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", userDate)))
            {
                using(var fileToCreate = File.Create(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", userDate)))
                {
                    using (var writer = new StreamWriter(fileToCreate))
                    {
						writer.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
					}
				}
            }
		}

        public DisplaySingleOrderResponse GetOrderToEdit(DateTime date, int orderNumber)
        {
            DisplaySingleOrderResponse response = new DisplaySingleOrderResponse();
            response.Order = _orderRepo.GetAllOrdersForDate(date).FirstOrDefault(o => o.OrderNumber == orderNumber);

            if ((response.Order == null))
            {
                response.Success = false;
                response.Message = $"Error: order {orderNumber} does not match up with any order on {date.ToShortDateString()}.";
                return response;
            }
            else
            {
                response.Order = _orderRepo.GetAllOrdersForDate(date).First(o => o.OrderNumber == orderNumber);
                response.Success = true;
                return response;
                //var orderToEdit = _orderRepo.GetAllOrdersForDate(date).First(o => o.OrderNumber == orderNumber);
                //return orderToEdit;
            }
        }

        public void RemoveThisOrder(Order order)
        {
            _orderRepo.RemoveThisOrder(order);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepo.ListProducts();
        }

        public void CommitOrder(Order order)
        {
            _orderRepo.CommitThisOrder(order);

        }

  
        public DisplayOrdersResponse GetAllOrdersForDate(DateTime userDate)
        {
            DisplayOrdersResponse response = new DisplayOrdersResponse();

            response.Orders = _orderRepo.GetAllOrdersForDate(userDate);

            if (response.Orders.Count == 0)
            {
                response.Success = false;
                response.Message = "The date you are looking for does not exist.";
            }
            else
            {
                response.Success = true;
                response.Message = "";
            }
            return response;

        }

        public void UpdateThisOrder(Order order)
        {
            _orderRepo.UpdateThisOrder(order);
        }

        public AddOrderResponse BuildNewOrder(DateTime date, string customerName, string state, string productType, decimal area)
        {
            AddOrderResponse response = new AddOrderResponse();
            response.Order = new Order();
            //if (!File.Exists(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", date)))
                //File.Create(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", date));
            if (_orderRepo.GetAllOrdersForDate(date).Count == 0)
            {
                response.Order.OrderNumber = 1;
            }
            else
            {
                var biggestOrderNumber = _orderRepo.GetAllOrdersForDate(date).Max(o => o.OrderNumber);

                response.Order.OrderNumber = biggestOrderNumber + 1;
            }
            if (date < DateTime.Today)
            {
                response.Success = false;
                response.Message = "Error: all orders must be in the future.";
                return response;
            }

            if (customerName == "")
            {
                response.Success = false;
                response.Message = "Error: you must enter a valid customer name.";
                return response;
            }

            if (area < 100M)
            {
                response.Success = false;
                response.Message = "Error: minimum order must be at least 100 sq feet.";
                return response;
            }

            if (_taxRepo.ListStateTax().All(s => s.StateName != (state.First().ToString().ToUpper() + state.Substring(1))))
            {
                response.Success = false;
                response.Message = "Error: the state you entered does not exist.";
                return response;
            }

            var stateTaxData = _taxRepo.ListStateTax().First(s => s.StateName == state);

            if (_productRepo.ListProducts().All(p => p.ProductType != (productType.First().ToString().ToUpper() + productType.Substring(1))))
            {
                response.Success = false;
                response.Message = "Error: we do not sell the product you entered.";
                return response;
            }
            var productInfo = _productRepo.ListProducts().First(p => p.ProductType == productType);

            response.Order.ProductType = productInfo.ProductType;
            response.Order.LaborCostPerSquareFoot = productInfo.LaborCostPerSqaureFoot;
            response.Order.CostPerSquareFoot = productInfo.CostPerSquareFoot;
            response.Order.TaxRate = stateTaxData.TaxRate;
            response.Order.Area = area;
            response.Order.State = state;
            response.Order.Date = date;
            response.Order.CustomerName = customerName;
            //order.Area = area;
            //_orderRepo.CommitThisOrder(response.Order);
            response.Success = true;
            return response;

        }

        public EditOrderResponse EditOrder(DateTime date, int orderNumber, string customerName, string state, string productType, decimal area)
        {
            EditOrderResponse response = new EditOrderResponse();
            response.Order = new Order();
            if (_taxRepo.ListStateTax().All(s => s.StateName != state.First().ToString().ToUpper() + state.Substring(1)))
            {
                response.Success = false;
                response.Message = $"Error: we currently do not sell in {response.Order.State}";
                return response;
            }
            var stateTaxData = _taxRepo.ListStateTax().First(s => s.StateName == state);

            if (_productRepo.ListProducts().All(p => p.ProductType != productType.First().ToString().ToUpper() + productType.Substring(1)))
            {
                response.Success = false;
                response.Message = $"Error: SG Flooring does not sell {response.Order.ProductType}";
                return response;
            }
            if(area < 100)
            {
                response.Success = false;
                response.Message = "Error: minimum oder area is 100.";
                return response;
            }
            var productInfo = _productRepo.ListProducts().First(p => p.ProductType == productType);
            response.Order.CostPerSquareFoot = productInfo.CostPerSquareFoot;
            response.Order.LaborCostPerSquareFoot = productInfo.LaborCostPerSqaureFoot;
            response.Order.ProductType = productInfo.ProductType;
            response.Order.Area = area;
            response.Order.TaxRate = stateTaxData.TaxRate;
            response.Order.State = stateTaxData.StateName;
            response.Order.CustomerName = customerName;
            response.Order.OrderNumber = orderNumber;
            response.Order.Date = date;
            response.Success = true;
            return response;
        }
       
    }
}
