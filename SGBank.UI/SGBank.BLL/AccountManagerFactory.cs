using System;
using System.Configuration;
using SGBank.Data;

namespace SGBank.BLL
{
    public static class AccountManagerFactory
    {
        public static AccountManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "FreeTest":
                    return new AccountManager(new FreeAccountTestRepository());
                default:
                    throw new Exception("Mode value in app confiog is not valid");
            }
        }
    }
}
