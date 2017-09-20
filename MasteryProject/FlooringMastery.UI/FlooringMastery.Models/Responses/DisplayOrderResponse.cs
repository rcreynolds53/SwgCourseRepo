using System;
namespace FlooringMastery.Models.Responses
{
    public class DisplayOrderResponse : Response
    {
        public Order Order { get; set; }
        public DisplayOrderResponse()
        {
        }
    }
}
