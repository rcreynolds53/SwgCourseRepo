using System;
using System.Configuration;
using FlooringMastery.Data;
using FlooringMastery.Data.TestRepos;

namespace FlooringMastery.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch(mode)
            {
                case "Test":
                    return new OrderManager(new TestOrderRepository(), new TestProductRepository(), new TestTaxRepository());
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}
