using System;
using System.Collections.Generic;
using System.IO;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Data.ProdRepos
{
    public class ProdProductRepository : IProductRepo
    {
        List<Product> _products = new List<Product>();
        public List<Product> ListProducts()
        {
            using (StreamReader reader = new StreamReader("/Data/System.IO/Products.txt")) 
            {
                reader.ReadLine();
                string line;
				while ((line = reader.ReadLine()) != null)
                {
                    Product product = new Product();
                    string[] columns = line.Split(',');

                    product.ProductType = columns[0];
                    product.CostPerSquareFoot = decimal.Parse(columns[1]);
                    product.LaborCostPerSqaureFoot = decimal.Parse(columns[2]);

                    _products.Add(product);
                }
                return _products;
			}
        }
    }
}
