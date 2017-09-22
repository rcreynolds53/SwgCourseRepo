using System;
using System.Collections.Generic;

namespace FlooringMastery.Models.Responses
{
    public class DisplayProductsResponse : Response
    {
        public List<Product> Products { get; set; }
    }
}
