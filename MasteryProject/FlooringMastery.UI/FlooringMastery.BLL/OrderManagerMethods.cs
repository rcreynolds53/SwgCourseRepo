using System;
using System.Collections.Generic;
using System.IO;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.BLL
{
    public class OrderManagerMethods
    {
        public string _filePath;
        public OrderManagerMethods(string filePath)
        {
            _filePath = filePath;
        }

        public List<Order> DisplayOrder()
        {
            using(StreamReader sr = new StreamReader())
            {
                
            }
        }
    }
}
