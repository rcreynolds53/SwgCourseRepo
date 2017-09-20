using System;
namespace FlooringMastery.Models.Responses
{
    public class Tax
    {
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }
        public decimal TaxRate { get; set; }

    }
}
