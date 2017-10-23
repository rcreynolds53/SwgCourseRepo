using DvdLibrary.Data;
using DvdLibrary.Data.Repositories;
using DvdLibrary.Models.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DvdLibraryAPI.UI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdController : ApiController
    {
        IDvdRepository _dvdRepository;
        public DvdController()
        {
            _dvdRepository = DataManagerFactory.Create();
        }



        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            return Ok(_dvdRepository.GetAllDvds());
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByTitle(string title)
        {
            List<Dvd> dvdsFound = _dvdRepository.GetDvdsByTitle(title);

            if(dvdsFound ==null)
            {
                return NotFound();
            }
            return Ok(dvdsFound);
        }

        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByYear(int releaseYear)
        {
            List<Dvd> dvdsFound = _dvdRepository.GetDvdsByYear(releaseYear);

            if(dvdsFound == null)
            {
                return NotFound();            
            }
            return Ok(dvdsFound);
        }

        [Route("dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllByDirector(string directorName)
        {
            List<Dvd> dvdsFound = _dvdRepository.GetDvdsByDirector(directorName);

            if(dvdsFound == null)
            {
                return NotFound();
            }

            return Ok(dvdsFound);
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllByRating(string rating)
        {
            List<Dvd> dvdsFound = _dvdRepository.GetDvdsByRating(rating);

            if(dvdsFound == null)
            {
                return NotFound();
            }
            return Ok(dvdsFound);
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(Dvd newDvd)
        {
            _dvdRepository.Create(newDvd);
            return Created($"dvd/{newDvd.DvdId}", newDvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public void Update(Dvd updatedDvd)
        {
            _dvdRepository.Update(updatedDvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            _dvdRepository.Delete(id);
        }
    }
}
