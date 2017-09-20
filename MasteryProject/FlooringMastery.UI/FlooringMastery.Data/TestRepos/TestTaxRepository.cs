using System;
using System.Collections.Generic;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Data.TestRepos
{
    public class TestTaxRepository : ITaxRepo
    {
        private static Tax _tax = new Tax()
        {
            StateAbbreviation = "MI",
            StateName = "Michigan",
            TaxRate = 6.00M,
        };

        public List<Tax> ListStateTax()
        {
            return new List<Tax>() { _tax };
        }
    }
}
