using DvdLibrary.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data
{
    public class DataManagerFactory
    {
        private IDvdRepository _dvdRepository;
        public DataManagerFactory(IDvdRepository dvdRepository)
        {
            _dvdRepository = dvdRepository;
        }
        public static IDvdRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "SampleData":
                    return new MockDvdRepository();
                case "ADO":
                    return new ADORepository();
                case "EntityFramework":
                    return new EFRepository();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
