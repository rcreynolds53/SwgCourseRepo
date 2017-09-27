using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipCalculator.Models
{
    public class CalculateTip
    {
        public decimal BillAmount { get; set; }
        public decimal PercentToTip { get; set; }
        public decimal? AmountToTip => BillAmount * (PercentToTip / 100);

    }
}