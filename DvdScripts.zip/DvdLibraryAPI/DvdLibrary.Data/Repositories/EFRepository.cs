using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Models.Models;
using System.Runtime.Remoting.Contexts;

namespace DvdLibrary.Data.Repositories
{
    public class EFRepository : IDvdRepository
    {
        DvdLibraryEntities context = new DvdLibraryEntities();

        public void Create(Dvd newDvd)
        {

            context.Dvds.Add(newDvd);
            context.SaveChanges();

        }

        public void Delete(int dvdId)
        {


            var dvd = (from d in context.Dvds
                       where d.DvdId == dvdId
                       select d).FirstOrDefault();
            context.Dvds.Remove(dvd);
            context.SaveChanges();

        }

        public List<Dvd> GetAllDvds()
        {

            var dvds = (from d in context.Dvds
                        select d).ToList();
            return dvds;

        }

        public Dvd GetDvdById(int dvdId)
        {

            var dvd = (from d in context.Dvds
                       where d.DvdId == dvdId
                       select d).FirstOrDefault();

            return dvd;

        }

        public List<Dvd> GetDvdsByDirector(string director)
        {

            var dvds = (from d in context.Dvds
                        where d.Director == director
                        select d).ToList();
            return dvds;


        }

        public List<Dvd> GetDvdsByRating(string rating)
        {
           var dvds = (from d in context.Dvds
                        where d.Rating == rating
                        select d).ToList();
            return dvds;
        }

        public List<Dvd> GetDvdsByTitle(string title)
        {
            var dvds = (from d in context.Dvds
                        where d.Title == title
                        select d).ToList();
            return dvds;
        }

        public List<Dvd> GetDvdsByYear(int releaseYear)
        {
            var dvds = (from d in context.Dvds
                        where d.ReleaseYear == releaseYear
                        select d).ToList();
            return dvds;
        }

        public void Update(Dvd updatedDvd)
        {
            context.Entry(updatedDvd).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}