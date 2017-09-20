using System;
using System.Collections.Generic;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Models.Interfaces
{
    public interface IProductRepo
    {
        List<Product> ListProducts();
    }
}
