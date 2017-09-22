using System;
using System.Collections.Generic;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Data.TestRepos
{
    public class TestTaxRepository : ITaxRepo
    {
        private static List<Tax> _tax = new List<Tax>
        {
            new Tax
            {
                StateAbbreviation = "MI",
                StateName = "Michigan",
                TaxRate = 5.75M,
            },
            new Tax
            {
                StateAbbreviation = "OH",
                StateName = "Ohio",
                TaxRate = 6.25M,
            },
             new Tax
            {
                StateAbbreviation = "MI",
                StateName = "Indiana",
                TaxRate = 6.00M,
            },
        };

        public List<Tax> ListStateTax()
        {
            return _tax; 
        }
    }
}
