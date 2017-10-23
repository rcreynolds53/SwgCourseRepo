using Dapper;
using DvdLibrary.Data;
using DvdLibrary.Data.Repositories;
using DvdLibrary.Models.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Tests
{
    [TestFixture]
    public class ADOTests
    {
        [SetUp]
        public void Init()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                var parameters = new DynamicParameters();

                conn.Execute("DbReset", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        [Test]
        public void CanLoadDvds()
        {
            var repo = new ADORepository();
            var dvds = repo.GetAllDvds();
            Assert.AreEqual(5, dvds.Count);

            Assert.AreEqual("Braveheart", dvds[0].Title);
            Assert.AreEqual("Mel Gibson", dvds[0].Director);
            Assert.AreEqual(1995, dvds[0].ReleaseYear);
        }
        [Test]
        public void CanCreateDvd()
        {
            var dvdToCreate = new Dvd();
            var repo = new ADORepository();

            dvdToCreate.Title = "Inception";
            dvdToCreate.ReleaseYear = 2010;
            dvdToCreate.Rating = "PG-13";
            dvdToCreate.Director = "Christopher Nolan";
            dvdToCreate.Notes = "Good, solid movie.";

            repo.Create(dvdToCreate);
            Assert.AreEqual(6, dvdToCreate.DvdId);
        }
        [Test]
        public void CanUpdateDvd()
        {
            var dvdToCreate = new Dvd();
            var repo = new ADORepository();

            dvdToCreate.Title = "Inception";
            dvdToCreate.ReleaseYear = 2010;
            dvdToCreate.Rating = "PG-13";
            dvdToCreate.Director = "Christopher Nolan";
            dvdToCreate.Notes = "Good, solid movie.";

            repo.Create(dvdToCreate);

            dvdToCreate.Title = "Inception";
            dvdToCreate.ReleaseYear = 2010;
            dvdToCreate.Rating = "R";
            dvdToCreate.Director = "Christopher Nolan";
            dvdToCreate.Notes = "I can change the notes and rating";

            repo.Update(dvdToCreate);

            var updatedDvd = repo.GetDvdById(6);

            Assert.AreEqual("R", updatedDvd.Rating);
            Assert.AreEqual("I can change the notes and rating", updatedDvd.Notes);

        }
        

        [Test]
        public void CanDeleteDvd()
        {
            var dvdToCreate = new Dvd();
            var repo = new ADORepository();

            dvdToCreate.Title = "Inception";
            dvdToCreate.ReleaseYear = 2010;
            dvdToCreate.Rating = "PG-13";
            dvdToCreate.Director = "Christopher Nolan";
            dvdToCreate.Notes = "Good, solid movie.";

            repo.Create(dvdToCreate);

            var dvdToDelete = repo.GetDvdById(6);
            Assert.IsNotNull(dvdToDelete);

            repo.Delete(6);

            dvdToDelete = repo.GetDvdById(6);
            Assert.IsNull(dvdToDelete);
        }

        [Test]
        public void CanLoadDvdsByDirector()
        {
            var repo = new ADORepository();
            var dvds = repo.GetDvdsByDirector("Christopher Nolan");

            Assert.AreEqual(2, dvds.Count);

            dvds = repo.GetDvdsByDirector("James Cameron");
            Assert.IsEmpty(dvds);
        }

        [Test]
        public void CanLoadDvdsByTitle()
        {
            var repo = new ADORepository();
            var dvds = repo.GetDvdsByTitle("Star Wars");

            Assert.AreEqual(1, dvds.Count);

            dvds = repo.GetDvdsByTitle("Tombstone");
            Assert.IsEmpty(dvds);
        }
        [Test]
        public void CanLoadDvdsByYear()
        {
            var repo = new ADORepository();
            var dvds = repo.GetDvdsByYear(1995);

            Assert.AreEqual(1, dvds.Count);

            dvds = repo.GetDvdsByYear(1111);
            Assert.IsEmpty(dvds);
        }

        [Test]
        public void CanLoadDvdsByRating()
        {
            var repo = new ADORepository();
            var dvds = repo.GetDvdsByRating("PG-13");
            Assert.AreEqual(2, dvds.Count);

            dvds = repo.GetDvdsByRating("NR");
            Assert.IsEmpty(dvds);
        }
    }
}
