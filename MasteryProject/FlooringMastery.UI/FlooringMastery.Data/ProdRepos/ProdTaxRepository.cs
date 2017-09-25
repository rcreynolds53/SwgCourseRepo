using System;
using System.Collections.Generic;
using System.IO;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Data.ProdRepos
{
    public class ProdTaxRepository : ITaxRepo
    {
        List<Tax> _taxes = new List<Tax>();
        public List<Tax> ListStateTax()
        {
            using(StreamReader reader = new StreamReader("/Data/System.IO/Taxes.txt"))
            {
                reader.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Tax stateTax = new Tax();
                    string[] columns = line.Split(',');
                    stateTax.StateAbbreviation = columns[0];
                    stateTax.StateName = columns[1];
                    stateTax.TaxRate = decimal.Parse(columns[2]);

                    _taxes.Add(stateTax);
                }
                return _taxes;
            }
        }
    }
}
