using System;
using System.Collections.Generic;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Data.TestRepos
{
    public class TestProductRepository : IProductRepo
    {
        private static List<Product> _products = new List<Product>
        {
            new Product
            {
                ProductType = "Carpet",
                CostPerSquareFoot = 2.25M,
                LaborCostPerSqaureFoot = 2.10M,
            },
			new Product
			{
				ProductType = "Tile",
				CostPerSquareFoot = 3.50M,
				LaborCostPerSqaureFoot = 4.15M,
			},
        };

        public List<Product> ListProducts()
        {
            return _products;
        }
    }
}
