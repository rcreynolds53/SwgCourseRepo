using ContractListService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ContractListService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContactController : ApiController
    {
        [Route("contacts/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllContacts()
        {
            return Ok(ContactRepository.GetAll());
        }

        [Route("contact/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetContact(int id) // paramenter must match the variable in the Route!!!!!!
        {
            Contact found = ContactRepository.GetContact(id);
            if (found == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(found);
            }
        }

        [Route("contact")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddContact(Contact contact)
        {
            ContactRepository.Add(contact);
            return Created($"contact/{contact.ContactId}", contact);
        }

        [Route("contacts/{id}")]
        [AcceptVerbs("PUT")]
        public void Update(int id, Contact contact)
        {
            ContactRepository.Update(contact);
        }

        [Route("contact/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            ContactRepository.Delete(id);
        }
    }
}
