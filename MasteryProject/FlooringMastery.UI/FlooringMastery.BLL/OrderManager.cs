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
        //public string _filePath;
        private IOrderRepo _orderRepo;
        private IProductRepo _productRepo;
        private ITaxRepo _taxRepo;
        public OrderManager(IOrderRepo orderRepo, IProductRepo productRepo,ITaxRepo taxRepo)
        {
            _orderRepo = orderRepo;
			_productRepo = productRepo;
			_taxRepo = taxRepo;


		}

        public DisplayOrderResponse DisplayOrderRules(Order order)
        {
            DisplayOrderResponse response = new DisplayOrderResponse();

            if (!File.Exists(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", order.Date)))
            {
                response.Success = false;
                response.Message = "Error: the date you entered is invalid.";
                return response;
            }
            _orderRepo.LoadOrdersList(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", order.Date));

            response.Success = true;
            return response;

        }
        public AddOrderResponse AddOrderRules(Order order, DateTime date, string customerName, decimal area, string state, string productType)
        {
            AddOrderResponse reponse = new AddOrderResponse();
            //List<Tax> stateTax = new List<Tax>();
            //List<Product> productsRepo = new List<Product>();

            if(!File.Exists(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", date)))
            {
                File.Create(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", date));
                order.OrderNumber = 1;
            }
            else
            {
                order.OrderNumber++;
            }

            if(date < DateTime.Today)
            {
                reponse.Success = false;
                reponse.Message = "Error: all orders must be in the future.";
                return reponse;
            }

            if(customerName == "")
            {
                reponse.Success = false;
                reponse.Message = "Error: you must enter a valid customer name.";
                return reponse;
            }

            if(area < 100M)
            {
                reponse.Success = false;
                reponse.Message = "Error: minimum order must be at least 100 sq feet.";
                return reponse;
            }

            if(_taxRepo.ListStateTax().Any(s=>s.StateName != state))
            {
                reponse.Success = false;
                reponse.Message = "Error: the state you entered does not exist.";
                return reponse;
            }

            var stateTaxData = _taxRepo.ListStateTax().First(s => s.StateName == state);

            if(_productRepo.ListProducts().Any(p=>p.ProductType != productType))
            {
                reponse.Success = false;
                reponse.Message = "Error: we do not sell the product you entered.";
                return reponse;
            }
            var productInfo = _productRepo.ListProducts().First(p => p.ProductType == productType);

            order.ProductType = productInfo.ProductType;
            order.LaborCostPerSquareFoot = productInfo.LaborCostPerSqaureFoot;
            order.CostPerSquareFoot = productInfo.CostPerSquareFoot;
            order.TaxRate = stateTaxData.TaxRate;
			order.Area = area;
			order.State = state;
            order.Date = date;
            order.CustomerName = customerName;
            order.Area = area;
            _orderRepo.SaveThisOrder(order);
            reponse.Order = order;
            reponse.Success = true;
			return reponse;
		}

        public EditOrderResponse EditOrderRules(Order order)
        {
            EditOrderResponse response = new EditOrderResponse();

            if(!File.Exists(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", order.Date)))
            {
                response.Success = false;
                response.Message = "Error: the date you entered is invalid.";
                return response;
            }
            _orderRepo.LoadOrdersList(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", order.Date));

            if(_orderRepo.LoadOrdersList(string.Format("/Data/System.IO/Orders_{0:MMddyyyy}.txt", order.Date)).Any(o=>o.OrderNumber != order.OrderNumber))
            {
                response.Success = false;
                response.Message = "Error: the order number entered was not a valid order number.";
                return response;
            }
            if(order.CustomerName != "")
            {
                response.Order.CustomerName = order.CustomerName;
            }

            if(order.State != "")
            {
                if(_taxRepo.ListStateTax().Any(s=>s.StateName != order.State))
                {
                    response.Success = false;
                    response.Message = $"Error: we currently do not sell in {order.State}";
                    return response;
                }
                var stateTaxData = _taxRepo.ListStateTax().First(s => s.StateName == order.State);


        }
    }
}
