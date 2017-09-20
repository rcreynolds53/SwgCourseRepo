using System;
using System.Collections.Generic;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Data.TestRepos
{
    public class TestProductRepository : IProductRepo
    {
        private static Product _product = new Product()
        {
            ProductType = "Carpet",
            CostPerSquareFoot = 2.25M,
            LaborCostPerSqaureFoot = 2.10M,
        };

        public List<Product> ListProducts()
        {
            return new List<Product>() { _product };
        }
    }
}
