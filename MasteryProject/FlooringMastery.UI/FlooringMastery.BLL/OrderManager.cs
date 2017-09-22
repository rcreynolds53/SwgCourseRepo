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

        public List<Product> GetAllProducts()
        {
            return _productRepo.ListProducts();
        }

        public void CommitOrder(Order order)
        {
            _orderRepo.CommitThisOrder(order);

        }

        //public void SaveOrders(List<Order> orders)
        //{
        //	if (File.Exists(_filePath))
        //		File.Delete(_filePath);
        //	using (StreamWriter sw = new StreamWriter(_filePath))
        //	{
        //		sw.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
        //		foreach (var order in orders)
        //		{
        //			sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", order.OrderNumber, order.CustomerName, order.State, order.TaxRate, order.ProductType, order.Area, order.CostPerSquareFoot, order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.Tax, order.Total));
        //		}
        //	}
        //}

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

        //      public DisplayOrdersResponse DisplayOrder(DateTime date, int orderNumber)
        //      {
        //	throw new NotImplementedException();
        //	DisplayOrdersResponse response = new DisplayOrdersResponse();
        //	if (_orderRepo.GetOrder(date, orderNumber).Equals(null))
        //	{
        //	    response.Success = false;
        //	    response.Message = "Error: the date you entered is invalid.";
        //	    return response;
        //	}
        //	_orderRepo.GetOrder(order.Date, order.OrderNumber);
        //	response.Success = true;
        //	return response;
        //}
        public AddOrderResponse BuildNewOrder(DateTime date, string customerName, string state, string productType, decimal area)
        {
            AddOrderResponse response = new AddOrderResponse();
            response.Order = new Order();
            //List<Tax> stateTax = new List<Tax>();
            //List<Product> productsRepo = new List<Product>();

            //if(_orderRepo.LoadOrdersList(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", date)).Equals(null))
            //{
            //    reponse.Order.OrderNumber = 1;
            //}
            //else
            //{
            //    var biggestNumber = _orderRepo.LoadOrdersList(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", date)).OrderByDescending(o => o.OrderNumber).First();
            //    reponse.Order.OrderNumber = biggestNumber.OrderNumber++;
            //}
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

            if (_taxRepo.ListStateTax().All(s => s.StateName != state))
            {
                response.Success = false;
                response.Message = "Error: the state you entered does not exist.";
                return response;
            }

            var stateTaxData = _taxRepo.ListStateTax().First(s => s.StateName == state);

            if (_productRepo.ListProducts().All(p => p.ProductType != productType))
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
            if (_taxRepo.ListStateTax().All(s => s.StateName != state))
            {
                response.Success = false;
                response.Message = $"Error: we currently do not sell in {response.Order.State}";
                return response;
            }
            var stateTaxData = _taxRepo.ListStateTax().First(s => s.StateName == state);

            if (_productRepo.ListProducts().All(p => p.ProductType != productType))
            {
                response.Success = false;
                response.Message = $"Error: SG Flooring does not sell {response.Order.ProductType}";
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
        //}
        //public EditOrderResponse EditOrder(Order order)
        //{
        //    EditOrderResponse response = new EditOrderResponse();

        //    if (_taxRepo.ListStateTax().All(s => s.StateName != order.State))
        //    {
        //        response.Success = false;
        //        response.Message = $"Error: we currently do not sell in {response.Order.State}";
        //        return response;
        //    }
        //    var stateTaxData = _taxRepo.ListStateTax().First(s => s.StateName == order.State);

        //    if (_productRepo.ListProducts().All(p => p.ProductType != order.ProductType))
        //    {
        //        response.Success = false;
        //        response.Message = $"Error: SG Flooring does not sell {response.Order.ProductType}";
        //        return response;
        //    }
        //    var productInfo = _productRepo.ListProducts().First(p => p.ProductType == order.ProductType);
        //    response.Order.CostPerSquareFoot = productInfo.CostPerSquareFoot;
        //    response.Order.LaborCostPerSquareFoot = productInfo.LaborCostPerSqaureFoot;
        //    response.Order.ProductType = productInfo.ProductType;
        //    response.Order.Area = order.Area;
        //    response.Order.TaxRate = stateTaxData.TaxRate;
        //    response.Order.State = stateTaxData.StateName;
        //    response.Order.CustomerName = order.CustomerName;
        //    response.Order.OrderNumber = order.OrderNumber;
        //    response.Order.Date = order.Date;
        //    response.Order = order;
        //    response.Success = true;
        //    return response;

        //    throw new NotImplementedException();
        //}
        //    if (_taxRepo.ListStateTax().All(s => s.StateName != state))
        //    {
        //        response.Success = false;
        //        response.Message = $"Error: we currently do not sell in {response.Order.State}";
        //        return response;
        //    }
        //    var stateTaxData = _taxRepo.ListStateTax().First(s => s.StateName == state);
        //    if (_productRepo.ListProducts().All(p => p.ProductType != productType))
        //    {
        //        response.Success = false;
        //        response.Message = $"Error: SG Flooring does not sell {response.Order.ProductType}";
        //        return response;
        //    }
        //    var productInfo = _productRepo.ListProducts().First(p => p.ProductType == productType);
        //    response.Order.CostPerSquareFoot = productInfo.CostPerSquareFoot;
        //    response.Order.LaborCostPerSquareFoot = productInfo.LaborCostPerSqaureFoot;
        //    response.Order.ProductType = productInfo.ProductType;
        //    response.Order.Area = area;
        //    response.Order.TaxRate = stateTaxData.TaxRate;
        //    response.Order.State = stateTaxData.StateName;
        //    response.Order.CustomerName = customerName;
        //    response.Order = response.Order;
        //    response.Success = true;
        //    return response;
        //    //throw new NotImplementedException();
        //
        //if (!string.IsNullOrWhiteSpace(response.Order.CustomerName))
        //{
        //    response.Order.CustomerName = response.Order.CustomerName;
        //}
        //else
        //{
        //    response.Order.CustomerName = response.Order.CustomerName;
        //}
        //if (_taxRepo.ListStateTax().All(s => s.StateName != response.Order.State))
        //{
        //    response.Success = false;
        //    response.Message = $"Error: we currently do not sell in {response.Order.State}";
        //    return response;
        //}
        //response.Order.State = response.Order.State;
        //var stateTaxData = _taxRepo.ListStateTax().First(s => s.StateName == response.Order.State);
        //response.Order.TaxRate = stateTaxData.TaxRate;
        //else
        //{
        //    order.State = response.Order.State;
        //    order.TaxRate = response.Order.TaxRate;
        //}
        //if (!string.IsNullOrWhiteSpace(order.ProductType))
        //{
        //    if (_productRepo.ListProducts().All(p => p.ProductType != order.ProductType))
        //    {
        //        response.Success = false;
        //        response.Message = $"Error: SG Flooring does not sell {order.ProductType}";
        //        return response;
        //    }
        //    order.ProductType = response.Order.ProductType;
        //    var productInfo = _productRepo.ListProducts().First(p => p.ProductType == order.ProductType);
        //    order.CostPerSquareFoot = response.Order.CostPerSquareFoot;
        //    order.LaborCostPerSquareFoot = response.Order.LaborCostPerSquareFoot;
        //}
        //else
        //{
        //    order.ProductType = response.Order.ProductType;
        //    order.CostPerSquareFoot = response.Order.CostPerSquareFoot;
        //    order.LaborCostPerSquareFoot = response.Order.LaborCostPerSquareFoot;
        //}
        //if(!string.IsNullOrWhiteSpace(order.Area.ToString()))
        //{
        //    if(order.Area < 100)
        //    {
        //        response.Success = false;
        //        response.Message = $"Error: orders must be a minimum of 100 square feet.";
        //        return response;
        //    }
        //    order.Area = response.Order.Area;
        //}
        //else
        //{
        //    order.Area = response.Order.Area;
        //}
        //response.Order = order;
        //response.Success = true;
        //return response;
        //if (_orderRepo.LoadOrdersList(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", order.Date)).Equals(null))
        //{
        //             response.Success = false;
        //             response.Message = "Error: the date you entered is invalid.";
        //             return response;
        //         }
        //_orderRepo.LoadOrdersList(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", order.Date));

        //if (_orderRepo.LoadOrdersList(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", order.Date)).Any(o=>o.OrderNumber != order.OrderNumber))
        //         {
        //             response.Success = false;
        //             response.Message = "Error: the order number entered was not a valid order number.";
        //             return response;
        //         }
    }
}
