using System;
using System.Configuration;
using SGBank.Data;

namespace SGBank.BLL
{
    public static class AccountManagerFactory
    {
		private const string _filepath = "/Users/macbookpro/Documents/SG-Bootcamp/dotnet-rob-reynolds/SGBank.UI/SGBank.UI/bin/Debug/Accounts.txt";
		public static AccountManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "FreeTest":
                    return new AccountManager(new FreeAccountTestRepository());
                case "BasicTest":
                    return new AccountManager(new BasicAccountTestRepository());
				case "PremiumTest":
					return new AccountManager(new PremiumAccountTestRepository());
				case "FileRepo":
                    return new AccountManager(new FileAccountRepository(_filepath));
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
