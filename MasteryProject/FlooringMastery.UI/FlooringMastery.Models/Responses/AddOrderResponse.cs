﻿using System;
using System.Collections.Generic;

namespace FlooringMastery.Models.Responses
{
    public class AddOrderResponse : Response
    {
        public Order Order { get; set; }
        //public Tax Tax { get; set; } 
    }
}
