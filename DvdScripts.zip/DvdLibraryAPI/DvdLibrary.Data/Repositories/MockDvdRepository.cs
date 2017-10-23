using DvdLibrary.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data
{
    public class MockDvdRepository : IDvdRepository
    {
        private static List<Dvd> _dvds;

        static MockDvdRepository()
        {

            _dvds = new List<Dvd>()
            {
                new Dvd { DvdId = 1, Title = "Braveheart", ReleaseYear = 1995, Rating = "R", Director= "Mel Gibson", Notes = "Freedoooommmmmm"  },
                new Dvd {DvdId = 2, Title = "Batman: Dark Knight", ReleaseYear = 2008, Rating = "PG-13", Director = "Christopher Nolan", Notes = "Great movie. Winner of multiple academy awards"},
                new Dvd { DvdId = 3, Title = "Inception", ReleaseYear= 2010, Rating= "PG-13", Director="Christopher Nolan", Notes="Movie about dream manipulation."},
                new Dvd {DvdId = 4, Title = "Star Wars", ReleaseYear = 1977, Rating= "PG", Director= "George Lucas", Notes="Great masterpiece, sith vs jedi."},
                new Dvd {DvdId = 5, Title = "Batman: Dark Knight Rises", ReleaseYear = 2012, Rating = "PG-13", Director = "Christopher Nolan", Notes="Great ending to a series. Well done."}
            };
        }

        public Dvd GetDvdById(int dvdId)
        {
            return _dvds.FirstOrDefault(d => d.DvdId == dvdId);
        }

        public List<Dvd> GetAllDvds()
        {
            return _dvds;
        }

        public List<Dvd> GetDvdsByTitle(string title)
        {
            return _dvds.Where(d => d.Title == title).ToList();
        }

        public List<Dvd> GetDvdsByYear(int releaseYear)
        {
            return _dvds.Where(d => d.ReleaseYear == releaseYear).ToList();
        }

        public List<Dvd> GetDvdsByDirector(string director)
        {
            return _dvds.Where(d => d.Director == director).ToList();
        }

        public List<Dvd> GetDvdsByRating(string rating)
        {
            return _dvds.Where(d => d.Rating == rating).ToList();
        }

        public void Create(Dvd newDvd)
        {
            if (_dvds.Any())
            {
                newDvd.DvdId = _dvds.Max(d => d.DvdId) + 1;
            }
            else
            {
                newDvd.DvdId = 1;
            }

            _dvds.Add(newDvd);
        }

        public void Update(Dvd updatedDvd)
        {
            _dvds.RemoveAll(d => d.DvdId == updatedDvd.DvdId);
            _dvds.Add(updatedDvd);
        }

        public void Delete(int dvdId)
        {
            _dvds.RemoveAll(d => d.DvdId == dvdId);
        }
    }
}
