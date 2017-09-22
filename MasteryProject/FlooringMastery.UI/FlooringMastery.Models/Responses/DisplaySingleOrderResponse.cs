using System;
namespace FlooringMastery.Models.Responses
{
    public class DisplaySingleOrderResponse : Response
    {
        public Order Order { get; set; }
    }
}
