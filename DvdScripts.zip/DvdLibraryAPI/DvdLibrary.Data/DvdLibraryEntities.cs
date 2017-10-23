using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Models;
using DvdLibrary.Models.Models;

namespace DvdLibrary.Data
{
    public class DvdLibraryEntities : DbContext
    {
        public DvdLibraryEntities() : base("DvdLibrary")
        {
        }
        public DbSet<Dvd> Dvds { get; set; }
    }
}


