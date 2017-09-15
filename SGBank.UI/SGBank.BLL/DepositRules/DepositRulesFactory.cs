using System;
using SGBank.Models;
using SGBank.Models.Interfaces;

namespace SGBank.BLL.DepositRules
{
    public class DepositRulesFactory
    {
        public static IDeposit Create(AccountType type)
        {
            switch(type)
            {
                case AccountType.Free:
                    return new FreeAccountDepositRule();
                default:
                    return new NoLimitDepositRule();

            }
        }
    }
}
