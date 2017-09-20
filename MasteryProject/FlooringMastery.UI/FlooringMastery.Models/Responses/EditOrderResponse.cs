using System;
namespace FlooringMastery.Models.Responses
{
    public class EditOrderResponse : Response
    {
        public Order Order { get; set; }
        public EditOrderResponse()
        {
        }
    }
}
