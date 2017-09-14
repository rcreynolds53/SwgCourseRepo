using System;
namespace SGBank.Models.Responses
{
    public class AccountDepositResponse : Response
    {
        public Account Account { get; set; }
        public decimal AmountDeposited { get; set; }
        public decimal OldBalance { get; set; }

    }
}
