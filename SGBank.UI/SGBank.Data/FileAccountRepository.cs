using System;
using SGBank.Models.Interfaces;
using System.IO;
using SGBank.Models;
using System.Collections.Generic;
using System.Linq;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        public List<Account> _account = new List<Account>();

        private const string _filepath = "/Users/macbookpro/Documents/SG-Bootcamp/dotnet-rob-reynolds/SGBank.UI/SGBank.UI/bin/Debug/Accounts.txt";
        //private static Account _account = new Account();
        //private Account _account = new Account();
        public FileAccountRepository()
        {
            //filepath = _filepath;
            List(_filepath);
        }

        public Account LoadAccount(string accountNumber)
        {
            var accountToLoad = _account.SingleOrDefault(acc => acc.AccountNumber == accountNumber);

            return accountToLoad;

        }

        public void SaveAccount(Account account)
        {
			if (File.Exists(_filepath))
			File.Delete(_filepath);
			using (StreamWriter sw = new StreamWriter(_filepath))
			{
			    sw.WriteLine("AccountNumber,Name,Balance,Type");
			    foreach (var acc in _account)
                {
					string accountType;
                    switch (acc.Type)
                    {
                        case AccountType.Free:
                            accountType = "F";
                            sw.WriteLine($"{acc.AccountNumber},{acc.Name},{acc.Balance},{accountType}");
                            break;
                        case AccountType.Basic:
                            accountType = "B";
                            sw.WriteLine($"{acc.AccountNumber},{acc.Name},{acc.Balance},{accountType}");
                            break;
                        case AccountType.Premium:
                            accountType = "P";
                            sw.WriteLine($"{acc.AccountNumber},{acc.Name},{acc.Balance},{accountType}");
                            break;
                    }
                }
			}
		}

        public void List(string filepath)
        {
            filepath = _filepath;
            using (StreamReader reader = new StreamReader(filepath))
            {
                reader.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Account newAccount = new Account();
                    string[] column = line.Split(',');
                    newAccount.AccountNumber = column[0];
                    newAccount.Name = column[1];
                    newAccount.Balance = decimal.Parse(column[2]);
                    switch (column[3].ToUpper())
                    {
                        case "F":
                            newAccount.Type = AccountType.Free;
                            break;
                        case "B":
                            newAccount.Type = AccountType.Basic;
                            break;
                        case "P":
                            newAccount.Type = AccountType.Premium;
                            break;
                    }
                    _account.Add(newAccount);
                }
            }
        }
    }
}
