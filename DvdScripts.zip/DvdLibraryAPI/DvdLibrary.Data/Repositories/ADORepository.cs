using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Models.Models;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.Data;

namespace DvdLibrary.Data.Repositories
{
    public class ADORepository : IDvdRepository
    {
        public void Create(Dvd newDvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                var parameters = new DynamicParameters();

                // declare output parameter
                parameters.Add("@DvdId",
                    dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Title", newDvd.Title);
                parameters.Add("@ReleaseYear", newDvd.ReleaseYear);
                parameters.Add("@Rating", newDvd.Rating);
                parameters.Add("@Director", newDvd.Director);
                parameters.Add("@Notes", newDvd.Notes);

                conn.Execute("InsertDvd",
                    parameters, commandType: CommandType.StoredProcedure);

                newDvd.DvdId = parameters.Get<int>("@DvdId");
            }


        }
    
        public void Delete(int dvdId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@DvdId",dvdId);
                conn.Execute("DvdDelete", parameters, commandType: CommandType.StoredProcedure);

            }

        }

        public List<Dvd> GetAllDvds()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                return conn.Query<Dvd>("DvdSelectAll", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public Dvd GetDvdById(int dvdId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@DvdId", dvdId);

                return conn.Query<Dvd>("GetDvdById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<Dvd> GetDvdsByDirector(string director)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@Director", director);

                return conn.Query<Dvd>("GetDvdsByDirector", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Dvd> GetDvdsByRating(string rating)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                var parameters = new DynamicParameters();
                parameters.Add("@Rating", rating);
                return conn.Query<Dvd>("GetDvdsByRating", parameters, commandType: CommandType.StoredProcedure).ToList();

            }
        }

        public List<Dvd> GetDvdsByTitle(string title)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                var parameters = new DynamicParameters();
                parameters.Add("@Title", title);
               return conn.Query<Dvd>("GetDvdsByTitle", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Dvd> GetDvdsByYear(int releaseYear)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                var parameters = new DynamicParameters();
                parameters.Add("@ReleaseYear", releaseYear);
                return conn.Query<Dvd>("GetDvdsByYear", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void Update(Dvd updatedDvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                var parameters = new DynamicParameters();
                parameters.Add("@DvdId", updatedDvd.DvdId);
                parameters.Add("@Title", updatedDvd.Title);
                parameters.Add("@ReleaseYear", updatedDvd.ReleaseYear);
                parameters.Add("@Rating", updatedDvd.Rating);
                parameters.Add("@Director", updatedDvd.Director);
                parameters.Add("@Notes", updatedDvd.Notes);
                conn.Execute("UpdateDvd", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
