using System;
namespace FlooringMastery.Models.Responses
{
    public class AddOrderResponse : Response
    {
        public Order Order { get; set; }
        //public Tax Tax { get; set; }
        //public Product Product { get; set; }
        public AddOrderResponse()
        {
        }
    }
}
