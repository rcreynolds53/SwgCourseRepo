using System;
namespace FlooringMastery.Models.Responses
{
    public class Product
    {
        public string ProductType { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSqaureFoot { get; set; }
    }
}
