using System;
using System.Collections.Generic;
namespace FlooringMastery.Models.Responses
{
    public class DisplayOrdersResponse : Response
    {
        public List<Order> Orders { get; set; }

    }
}
