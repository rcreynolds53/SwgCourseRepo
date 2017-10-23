using DvdLibrary.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data
{
    public interface IDvdRepository
    {
        Dvd GetDvdById(int dvdId);
        List<Dvd> GetAllDvds();
        List<Dvd> GetDvdsByTitle(string title);
        List<Dvd> GetDvdsByYear(int releaseYear);
        List<Dvd> GetDvdsByDirector(string director);
        List<Dvd> GetDvdsByRating(string rating);
        void Create(Dvd newDvd);
        void Update(Dvd updatedDvd);
        void Delete(int dvdId);
    }
}